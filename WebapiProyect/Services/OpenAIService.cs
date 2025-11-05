using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using WebapiProyect.Interfaces;
public class OpenAIService : IOpenAIService
{
    private readonly OpenAIClient _client;
    private readonly IDataAccessService _dataAccess;
    private readonly Model ModeloRazonamiento = Model.GPT4o;

    public OpenAIService(IConfiguration config, IDataAccessService dataAccess)
    {
        var apiKey = config["OpenAI:ApiKey"];
        _client = new OpenAIClient(apiKey);
        _dataAccess = dataAccess;
    }

    public async Task<string> probarConexion()
    {
        try
        {
            // 🚨 SOLUCIÓN: Usar SystemMessage y UserMessage en lugar de ChatMessage(ChatRole, ...)
            var messages = new List<Message>
            {
                new Message(Role.System, "Eres un asistente útil que responde con una sola palabra."),
                new Message(Role.User, "Hola!" )
            };

            var chatRequest = new ChatRequest(
               messages,
               model: Model.GPT3_5_Turbo,
               maxTokens: 5
             );

            var response = await _client.ChatEndpoint.GetCompletionAsync(chatRequest);
            var content = response.Choices[0].Message.Content?.ToString().Trim() ?? string.Empty;

            return $"Conexión exitosa. Respuesta de OpenAI: {content.Trim()}";
        }
        catch (Exception ex)
        {
            return $"Error al conectar con OpenAI: {ex.Message}";
        }
    }
 

    public async Task<string> procesarDataAsync(string prompt)
    {

        var sqlQuery = await GenerarSQLQuery(prompt);
        if (string.IsNullOrEmpty(sqlQuery))
        {
            return "Lo siento, no pude generar una consulta SQL para tu solicitud.";
        }
        var dataJson = await _dataAccess.ExecuteSqlGetJsonAsync(sqlQuery);

        if (string.IsNullOrEmpty(dataJson))
        {
            return "La consulta SQL no devolvió datos.";
        }
        var finalResponse = await AnalizadorDatos(prompt, dataJson);
        return finalResponse;

    }

    private async Task<string > GenerarSQLQuery(string prompt)
    {
        string dbSchema = @"
Base de datos de gestión integral de una granja con 50 tablas, organizadas por módulos de la siguiente manera:

Módulo de Personal y Organización
- cargo: (id_cargo, nombre) - Tipos de puesto.
- empleado: (id_empleado, nombre, apellido, cargo_id, salario_base) - FK a cargo.
- usuario: (id_usuario, nombre, rol) - Usuarios del sistema.
- turno: (id_turno, empleado_id, fecha, hora_inicio, hora_fin) - FK a empleado.
- planilla: (id_planilla, empleado_id, mes, anio, sueldo) - FK a empleado.
- capacitacion: (id_capacitacion, empleado_id, tema) - FK a empleado (quien imparte).
- participacion_capacitacion: (id_participacion, empleado_id, capacitacion_id) - FKs a empleado y capacitacion.

Módulo de Inventario (Productos, Alimentos, Salud y Herramientas)
- producto: (id_producto, nombre, tipo, precio_base) - Productos agrícolas o genéricos.
- proveedor: (id_proveedor, nombre, tipo_proveedor) - Proveedores de insumos.
- cliente: (id_cliente, nombre, tipo_cliente).
- producto_alimenticio: (id_producto_alimenticio, nombre, proveedor_id, precio_unitario) - FK a proveedor.
- suplemento: (id_suplemento, nombre, tipo, nutrientes).
- medicamento: (id_medicamento, nombre, laboratorio).
- herramienta: (id_herramienta, nombre, tipo).
- inventario_alimento: (id_inventario_alimento, producto_alimenticio_id, cantidad, fecha_vencimiento) - FK a producto_alimenticio.
- inventario_suplemento: (id_inventario_suplemento, suplemento_id, cantidad, fecha_vencimiento) - FK a suplemento.
- inventario_medicamento: (id_inventario_medicamento, medicamento_id, cantidad, fecha_vencimiento) - FK a medicamento.
- inventario_herramienta: (id_inventario_herramienta, herramienta_id, cantidad, estado) - FK a herramienta.

Módulo Animal y Sanidad
- especie: (id_especie, nombre).
- raza: (id_raza, nombre, especie_id) - FK a especie.
- animal: (id_animal, codigo, especie_id, raza_id, sexo, fecha_nacimiento, peso, estado) - FKs a especie y raza.
- vacuna: (id_vacuna, nombre, dosis).
- tratamiento: (id_tratamiento, nombre, tipo).
- historial_sanitario: (id_historial, animal_id, diagnostico) - FK a animal.
- aplicacion_vacuna: (id_aplicacion_vacuna, animal_id, vacuna_id, empleado_id) - FKs a animal, vacuna, empleado.
- aplicacion_tratamiento: (id_aplicacion_tratamiento, animal_id, tratamiento_id, veterinario_id) - FKs a animal, tratamiento, empleado.
- desparasitacion: (id_desparasitacion, animal_id, empleado_id) - FKs a animal, empleado.
- consumo_animal: (id_consumo_animal, animal_id, producto_alimenticio_id, cantidad) - FKs a animal, producto_alimenticio.

Módulo de Reproducción
- gestacion: (id_gestacion, hembra_id, fecha_inicio, fecha_estimada_parto) - FK a animal.
- registro_parto: (id_registro_parto, madre_id, numero_crias) - FK a animal.
- nacimiento: (id_nacimiento, madre_id, cria_animal_id, peso) - FKs a animal (madre) y animal (cría).

Módulo de Producción
- ordeno: (id_ordeno, animal_id, litros, ordenador_id) - FKs a animal, empleado.
- produccion_leche: (id_produccion_leche, animal_id, litros, empleado_id) - FKs a animal, empleado.
- produccion_carne: (id_produccion_carne, animal_id, peso_canal, destino) - FK a animal.
- reporte_produccion: (id_reporte_produccion, fecha, empleado_id) - FK a empleado.

Módulo de Finanzas y Transacciones
- venta: (id_venta, cliente_id, fecha, total, tipo_pago) - FK a cliente.
- detalle_venta: (id_detalle_venta, venta_id, producto_id, animal_id, cantidad) - FKs a venta, producto, animal (si se vende un animal).
- compra: (id_compra, proveedor_id, fecha, total, tipo_pago) - FK a proveedor.
- detalle_compra: (id_detalle_compra, compra_id, producto_id, cantidad) - FKs a compra, producto.
- factura: (id_factura, cliente_id, proveedor_id, monto_total) - FKs a cliente (si es venta) y proveedor (si es compra).
- pago: (id_pago, factura_id, monto, tipo_pago) - FK a factura.
- reporte_financiero: (id_reporte_financiero, fecha, empleado_id, ingresos, egresos, balance) - FK a empleado.

Módulo de Infraestructura y Logística
- establo: (id_establo, nombre, empleado_id) - FK a empleado.
- potrero: (id_potrero, nombre, hectareas).
- corral: (id_corral, nombre, capacidad).
- maquinaria: (id_maquinaria, nombre, estado).
- herramienta: (id_herramienta, nombre, tipo).
- transporte: (id_transporte, vehiculo, capacidad).
- envio: (id_envio, venta_id, transporte_id, empleado_id) - FKs a venta, transporte, empleado.
- infraestructura_mantenimiento: (id_infra_mant, infraestructura_tipo, infraestructura_id, empleado_id) - FK a empleado.

Instrucciones: Genera SOLO la consulta SQL (SQL Server dialect) que responde a la siguiente solicitud del usuario basada en el esquema de la base de datos proporcionado.
***REGLA CRÍTICA: Usa CORCHETES [ ] para delimitar TODAS las tablas y columnas. NUNCA uses comillas inversas (`).***
Ejemplo: 'Animales Activos' -> SELECT * FROM animal WHERE estado = 'activo';
        ";

        var messages = new List<Message>
        {
            new Message(Role.System, dbSchema),
            new Message(Role.User, prompt)
        };

        var request = new ChatRequest
        (
            messages,
            model: ModeloRazonamiento,
            maxTokens: 500
        ) ;


        var response = await _client.ChatEndpoint.GetCompletionAsync(request);
        var sqlQuery = response.Choices[0].Message.Content?.ToString().Trim() ?? string.Empty;
        sqlQuery = sqlQuery.Replace("```sql", string.Empty, StringComparison.OrdinalIgnoreCase);
        sqlQuery = sqlQuery.Replace("```", string.Empty);

        sqlQuery = sqlQuery.Replace("`", string.Empty);

        sqlQuery = sqlQuery.Trim();
        Console.WriteLine("Consulta SQL generada: " + sqlQuery);
        return sqlQuery;
    }

    private async Task<string> AnalizadorDatos(string promptOriginal, string dataJson)
    {
        Console.WriteLine("dataaaaaa jsonn:" + dataJson);
        var today = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy", new System.Globalization.CultureInfo("es-GT")); 
        string systemPrompt = $@"
            **ERES UN ANALISTA DE DATOS CON RIGOR EXTREMO.** Tu ÚNICA fuente de información para los números y el desglose es el JSON que se adjunta a continuación. NO INVENTES ni alucines datos. Si el JSON no tiene la información (ej. tendencia), omítela o indícalo.
            
            Requisitos del resumen:
            1. Debe ser fácil de leer, como un reporte ejecutivo.
            2. Incluye un encabezado con el dato principal (ej: 'Actualmente tienes X animales activos...').
            3. Proporciona un desglose de los datos (como en el ejemplo de '265 animales saludables').
            4. Añade un comentario de 'Tendencia' (si los datos lo permiten, de lo contrario, ignóralo).
            5. Finaliza OBLIGATORIAMENTE con la fecha de hoy. La fecha de hoy es: {today}.

            La pregunta original del usuario fue: '{promptOriginal}'

            Aquí están los datos JSON resultantes de la consulta:
            {dataJson}
        ";
        var messages = new List<Message>
        {
            new Message(Role.System, systemPrompt)
        };

        var request = new ChatRequest
        (
            messages,
            model: ModeloRazonamiento,
            maxTokens: 300
        );
        var response = await _client.ChatEndpoint.GetCompletionAsync(request);

        var respuesta = response.Choices[0].Message.Content?.ToString().Trim() ?? string.Empty;
        return respuesta;
    }

}
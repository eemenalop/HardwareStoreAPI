API RESTful con ASP.NET Core y Entity Framework Core que gestione un sistema básico de facturación para una ferretería. El sistema debe permitir:
Registrar y administrar
Crear, consultar, y anular
Agregar múltiples a cada factura
Realizar operaciones CRUD
🔧 Funcionalidades del Sistema


📌 Todas las operaciones deben exponerse como endpoints RESTful, utilizando los métodos HTTP apropiados (GET, POST, PUT, DELETE). Recordar cómo estructurar los endpoints correctamente forma parte de la tarea.


🧑‍💼 Gestión de Empleados
Listar todos los empleados
Obtener los datos de un empleado específico por su ID
Crear un nuevo empleado
Actualizar los datos de un empleado existente
Eliminar un empleado del sistema

📦 Gestión de Items
Listar todos los items disponibles
Obtener los detalles de un item específico
Crear un nuevo item
Actualizar la información de un item
Eliminar un item del sistema

🧾 Gestión de Facturas
Listar todas las facturas registradas (excluyendo las anuladas)
Ver los detalles de una factura específica
Crear una nueva factura (debe poder crearse sin items inicialmente)
Actualizar los datos generales de una factura (como el empleado responsable)
Anular una factura (soft delete marcando EsAnulada = true, sin eliminar el registro)

🧮 Gestión del Detalle de Factura (FacturaDetalle)
Agregar un item a una factura existente indicando la cantidad
Modificar un item existente en una factura (cantidad o precio unitario)
Eliminar un item específico de una factura
Ver el detalle completo (items asociados) de una factura

⚠️
Un item que no tiene existencia (StockDisponible = 0 o menor que la cantidad solicitada) a una factura.
Si se intenta crear una factura con items sin stock suficiente, hasta que se eliminen dichos items de la petición o se actualice su stock en el sistema.
Esta validación debe aplicarse tanto al momento de agregar items como al momento de confirmar o guardar una factura.

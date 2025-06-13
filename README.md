# ProyectoDotnetFinal
Sistema de Gestión del Centro Deportivo Universitario

## Descripción general

El propósito de este proyecto es expandir las capacidades del “Sistema de Gestión del Centro Deportivo Universitario” que se desarrolló previamente.

Utilizando el proyecto original como base, se deberán integrar las siguientes funcionalidades adicionales:

### Gestión de Usuarios:

- Desarrollar la funcionalidad necesaria para la gestión de usuarios del sistema. Cada
usuario debe tener nombre, apellido, correo electrónico, contraseña y una lista de
permisos.
- Los usuarios pueden tener múltiples permisos. En principio sólo el Administrador
tendrá los permisos necesarios para listar, dar de baja y modificar cualquier usuario
o sus permisos. Sin embargo, el Administrador también podrá otorgar a otros
usuarios los permisos de UsuarioAlta, UsuarioBaja y UsuarioModificación. De esta
manera, la gestión de usuarios también podrá ser realizada por aquellos
autorizados.
- El primer usuario que se registre en el sistema será el Administrador, quien contará
con todos los permisos del sistema.
- Definir los repositorios y casos de uso que se consideren necesarios. También definir
un validador para la entidad Usuario (nombre, apellido y contraseñas requeridos).
Servicio de Autorización:
- Desarrollar el servicio de autorización ServicioAutorizacion que implemente la
interfaz IServicioAutorizacion, reemplazando al servicio de autorización provisorio
de la entrega inicial.
- Este servicio debe verificar realmente si el usuario tiene el permiso requerido.

### Persistencia de Datos:

- En el proyecto CentroEventos.Repositorios, emplear Entity Framework Core para
persistir datos en una base de datos SQLite, siguiendo la metodología “code first”.

### Interfaz de Usuario:

- Descartar el proyecto CentroEventos.Consola de la primera entrega.
- Desarrollar una nueva interfaz de usuario en un proyecto llamado CentroEventos.UI utilizando Blazor.
  Diseñar libremente esta interfaz de manera que toda la funcionalidad desarrollada en la primera entrega sea accesible desde esta interfaz, agregando la gestión de usuarios requerida.

### Flujo de Gestión:

- Al iniciar la aplicación, se presentará una pantalla de bienvenida que permitirá a los usuarios iniciar sesión o registrarse.
- En caso de registro, se proporcionará un formulario para ingresar los datos personales y establecer una contraseña.
- Los usuarios tendrán la libertad de modificar sus datos personales y contraseña en cualquier momento.
- Por simplicidad no se implementará ningún mecanismo de recuperación de contraseña.
  En caso de olvido de contraseña, el usuario deberá contactar al Administrador o a otro usuario con permiso adecuado para restablecerla.
  El contacto es de manera directa con la persona, no se debe implementar en el sistema.
- Las contraseñas no se almacenarán directamente en la base de datos; en su lugar, se utilizará una función de hash para mayor seguridad.

### Almacenamiento del hash

- El hash de la contraseña debe almacenarse en la base de datos, nunca la contraseña en sí.
  Para verificar la identidad del usuario al iniciar sesión, se vuelve a calcular el hash de la contraseña ingresada y se compara con el hash almacenado.
  Si los hashes coinciden, el usuario ha ingresado la contraseña correcta y se le permite acceder al sistema.

### Permisos de Usuario:

- Los usuarios nuevos contarán inicialmente solo con permisos de lectura. Es decir pueden ver las reservas, socios y eventos.
- Solo el Administrador o los usuarios con los permisos de gestión de usuarios podrán asignar permisos adicionales.

### Acceso Administrativo:

- Una vez iniciada la sesión, el menú de gestión de usuarios será visible sólo si quien ingresó
  posee alguno de los permisos de gestión de usuarios o es el Administrador.

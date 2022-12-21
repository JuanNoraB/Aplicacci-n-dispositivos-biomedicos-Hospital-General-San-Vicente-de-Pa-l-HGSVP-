# Dispositivos-Biomédicos-Seiton
Primera Etapa 

El siguiente software es destinado al Hospital San Vicente de Paul en la ciudad de Ibarra. La presente documentacion corresponde a DISPOSITIVOS BIOMEDICOS.
Las herramientas utilizadas fueron PostgreSQL y Visual Studio 2019.

La plantilla del diseño se encuentra en el documento "Hoja de vida Dispositivo Biomédicos"

# Dispositivos Biomédicos

## Visual Studio 2019

La carpeta DISPOSITIVOS contiene los archivos:
- Busqueda.cs : Código C#
- Busqueda.Designer: Interfaz
- Hoja de vida.cs: Código C#
- Hoja de vida.Designer: Interfaz
- Main Dispositivos: Código C#
- Main Dispositivos.Designer: Interfaz (Landing Principal) 

## PostgreSQL

La carpeta POSTGRESQL contiene los archivos:

- hoja_de_vida_seiton: Codigo PostgreSQL para la base de datos 
- README.md: Intrucciones con respecto al código.

# Futuros Trabajos y Estado del Proyecto

La primera fase de SEITON fue el diseño de una aplicación para la gestion del area de TRANSPORTE y DISPOSITIVOS BIOMEDICOS. Dentro del area de DISPOSITIVOS BIOMEDICOS
quedaron trabajos pendientes tales como:
- Implementar el sistema de ingreso de Firmas
- Implementar el sistema de ingreso de fotografias de los dispositivos biomédicos en su hoja de vida.
- Mejorar la interfaz de busqueda
- Mejorar la interfaz del software
- Agregar mas funcionalidades de acuerdo a los lideres a cargo de SEITON
- Solucionar el problema de la actualización de las hojas de vida de dispositivos biomédicos donde hasta el momento la plataforma si se ingresa un numero de serie que ya existe se mezclan los datos y no se obtiene el resultado deseado. Se planteo en PostgreSQL con un trigger dar solución a este problema, el codigo esta en el documento de hoja_de_vida_seiton pero necesita varios cambios para que cumpla con el proposito

Recordatorio: Para la ejecución en sus ordenadores, deben de cambiar código de la conexion entre PostgreSQL y Visual Studio 2019 tales como el local host, puerto, base de datos y contraseña con los datos de su base de datos. Además de instalar en Visual Studio 2019 en "Manage Nuget Packages for Solution" la extension "Npgsql"

- Contacto: andres.quelal@yachaytech.edu.ec

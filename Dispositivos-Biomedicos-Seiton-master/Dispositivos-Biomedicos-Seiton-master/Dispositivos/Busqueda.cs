using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Dispositivos
{
    public partial class Busqueda : Form
    {
        NpgsqlConnection cn;
        NpgsqlCommand cme = new NpgsqlCommand();
        NpgsqlDataReader dm;


        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {

            //Conectar a una base de datos
            //string str = "Server=127.0.0.1;Port=5432;Database=backup_dispositivos_biomedicos;User Id=postgres;Password=hgsvp;";
            string str = "Server=127.0.0.1;Port=5432;Database=backup_dispositivos_biomedicos;User Id=postgres;Password=hpenvy135;";
            
            cn = new NpgsqlConnection();
            cn.ConnectionString = str;
            cn.Open();

            //Cargar los datos de la grilla final
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grilla_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void boton_busqueda_Click(object sender, EventArgs e)
        {

            grilla_1.ColumnCount = 8;
            grilla_1.Columns[0].HeaderText = "Fecha de Emisión";
            grilla_1.Columns[1].HeaderText = "Serie";
            grilla_1.Columns[2].HeaderText = "Tipo de Registro";
            grilla_1.Columns[3].HeaderText = "Tipo de Bien";
            grilla_1.Columns[4].HeaderText = "Nombre";
            grilla_1.Columns[5].HeaderText = "Marca";
            grilla_1.Columns[6].HeaderText = "Modelo";
            grilla_1.Columns[7].HeaderText = "Año de fabricación";

            //Llamar datos desde la grilla
            grilla_1.Rows.Clear();
            //NpgsqlCommand cme = new NpgsqlCommand();
            //cme.CommandText = " SELECT R.fecha AS fecha_emision, R.nombre_resp AS Responsable_registro, E.nombre, E.serie, E.modelo, E.fab_year, B.estatus, U.servicio FROM registro_elab R INNER JOIN equip_description E ON R.n10_serie = E.serie INNER JOIN estado_bien B ON E.serie = B.n7_serie INNER JOIN ubicacion_equipo U ON U.n4_serie = E.serie GROUP BY R.fecha, E.nombre, E.serie, R.nombre_resp, E.modelo,E.fab_year, B.estatus, U.servicio ORDER BY R.fecha desc;";
            cme.CommandText = "select E.fecha as fecha_emision,R.serie,R.tipo_registro,R.tipo_bien,R.Nombre,R.marca,R.modelo,R.fab_year from registro_elab E,equip_description R where R.serie = E.n10_serie and R.tipo_registro = E.n10_tipo_registro and R.serie ='" + serie_busqueda.Text + "';";
            cme.Connection = cn;
            //NpgsqlDataReader
            dm = cme.ExecuteReader();
            while (dm.Read())
            {
                grilla_1.Rows.Add(dm[0], dm[1], dm[2], dm[3], dm[4], dm[5], dm[6], dm[7]);
            }
            dm.Close();

            //Cargar los datos de la descripcion bien
            desp_bien_busqueda.ColumnCount = 7;
            desp_bien_busqueda.Columns[0].HeaderText = "Bien";
            desp_bien_busqueda.Columns[1].HeaderText = "Nombre Registro";
            desp_bien_busqueda.Columns[2].HeaderText = "Marca";
            desp_bien_busqueda.Columns[3].HeaderText = "Modelo";
            desp_bien_busqueda.Columns[4].HeaderText = "Serie";
            desp_bien_busqueda.Columns[5].HeaderText = "Tipo de Registro";
            desp_bien_busqueda.Columns[6].HeaderText = "Año de Fabricación";

            //Ejecucion en postgresql
            desp_bien_busqueda.Rows.Clear();
            NpgsqlCommand sma = new NpgsqlCommand();
            sma.CommandText = " SELECT * FROM equip_description WHERE serie = '" + serie_busqueda.Text + "';";
            sma.Connection = cn;
            NpgsqlDataReader da = sma.ExecuteReader();
            while (da.Read())
            {
                desp_bien_busqueda.Rows.Add(da[0], da[1], da[2], da[3], da[4], da[5],da[6]);
            }
            da.Close();

            //PARTE 2: Cargar los datos de la datos tecnicos
            grilla_2.ColumnCount = 12;
            grilla_2.Columns[0].HeaderText = "Numero de Serie";
            grilla_2.Columns[1].HeaderText = "Tipo de Registro";
            grilla_2.Columns[2].HeaderText = "Voltaje";
            grilla_2.Columns[3].HeaderText = "Fase Voltaje";
            grilla_2.Columns[4].HeaderText = "Corriente";
            grilla_2.Columns[5].HeaderText = "Potencia";
            grilla_2.Columns[6].HeaderText = "Frecuencia";
            grilla_2.Columns[7].HeaderText = "Batería";
            grilla_2.Columns[8].HeaderText = "Canales";
            grilla_2.Columns[9].HeaderText = "Memoria";
            grilla_2.Columns[10].HeaderText = "Impresión";
            grilla_2.Columns[11].HeaderText = "Comentarios";

            //Ejecucion en postgresql
            grilla_2.Rows.Clear();
            NpgsqlCommand smb = new NpgsqlCommand();
            smb.CommandText = " SELECT * FROM equip_tdata WHERE n_serie = '" + serie_busqueda.Text + "';";
            smb.Connection = cn;
            NpgsqlDataReader db = smb.ExecuteReader();
            while (db.Read())
            {
                grilla_2.Rows.Add(db[0], db[1], db[2], db[3], db[4], db[5], db[6], db[7], db[8], db[9], db[10],db[11]);
            }
            db.Close();


            //PARTE 3: Cargar los datos de la DATOS ECONOMICOS
            
            grilla_3.ColumnCount = 7;
            grilla_3.Columns[0].HeaderText = "Numero de Serie";
            grilla_3.Columns[1].HeaderText = "tipo de registro";
            grilla_3.Columns[2].HeaderText = "Valor de Adquisición";
            grilla_3.Columns[3].HeaderText = "Numero de Factura";
            grilla_3.Columns[4].HeaderText = "Forma de Adquisición";
            grilla_3.Columns[5].HeaderText = "Fecha Adquisición";
            grilla_3.Columns[6].HeaderText = "Vida útil";

            //Ejecucion en postgresql
            grilla_3.Rows.Clear();
            NpgsqlCommand smc = new NpgsqlCommand();
            smc.CommandText = " SELECT * FROM datos_economicos WHERE n3_serie = '" + serie_busqueda.Text + "';";
            smc.Connection = cn;
            NpgsqlDataReader dc = smc.ExecuteReader();
            while (dc.Read())
            {
                grilla_3.Rows.Add(dc[0], dc[1], dc[2], dc[3], dc[4], dc[5],dc[6]);
            }
            dc.Close();

            //PARTE 4: Cargar los datos de la UBICACIÓN DEL EQUIPO

            grilla_4.ColumnCount = 10;
            grilla_4.Columns[0].HeaderText = "Numero de Serie";
            grilla_4.Columns[1].HeaderText = "tipo de registro";
            grilla_4.Columns[2].HeaderText = "Unidad Operativa";
            grilla_4.Columns[3].HeaderText = "Servicio";
            grilla_4.Columns[4].HeaderText = "Sub-Servicio";
            grilla_4.Columns[5].HeaderText = "Nombre Custodio";
            grilla_4.Columns[6].HeaderText = "Zona";
            grilla_4.Columns[7].HeaderText = "Distrito";
            grilla_4.Columns[8].HeaderText = "Provincia";
            grilla_4.Columns[9].HeaderText = "Ciudad";

            //Ejecucion en postgresql
            grilla_4.Rows.Clear();
            NpgsqlCommand smd = new NpgsqlCommand();
            smd.CommandText = " SELECT * FROM ubicacion_equipo WHERE n4_serie = '" + serie_busqueda.Text + "';";
            smd.Connection = cn;
            NpgsqlDataReader dd = smd.ExecuteReader();
            while (dd.Read())
            {
                grilla_4.Rows.Add(dd[0], dd[1], dd[2], dd[3], dd[4], dd[5], dd[6], dd[7], dd[8],dd[9]);
            }
            dd.Close();

            //PARTE 4: Cargar los datos de la DATOS DE PROOVEDOR

            grilla_5.ColumnCount = 26;
            
            grilla_5.Columns[0].HeaderText = "Numero de Serie";
            grilla_5.Columns[1].HeaderText = "Tipo de Registro ";
            grilla_5.Columns[2].HeaderText = "Fabricante";
            grilla_5.Columns[3].HeaderText = "Dirección Fabricante";
            grilla_5.Columns[4].HeaderText = "Teléfono Fabricante";
            grilla_5.Columns[5].HeaderText = "Email Fabricante";

            grilla_5.Columns[6].HeaderText = "Proveedor";
            grilla_5.Columns[7].HeaderText = "Dirección Proveedor";
            grilla_5.Columns[8].HeaderText = "Teléfono Proveedor";
            grilla_5.Columns[9].HeaderText = "Email Proveedor";
            grilla_5.Columns[10].HeaderText = "Nombre Proveedor";

            grilla_5.Columns[11].HeaderText = "Representante en el País";
            grilla_5.Columns[12].HeaderText = "Dirección Representante";
            grilla_5.Columns[13].HeaderText = "Teléfono Representante";
            grilla_5.Columns[14].HeaderText = "Email Representante";
            grilla_5.Columns[15].HeaderText = "Nombre Representante";


            grilla_5.Columns[16].HeaderText = "Proveedor Mantenimiento";
            grilla_5.Columns[17].HeaderText = "Dirección Mantenimiento";
            grilla_5.Columns[18].HeaderText = "Teléfono Mantenimiento";
            grilla_5.Columns[19].HeaderText = "Email Mantenimiento";
            grilla_5.Columns[20].HeaderText = "Nombre Mantenimiento";

            grilla_5.Columns[21].HeaderText = "Proveedor Calibración";
            grilla_5.Columns[22].HeaderText = "Dirección Calibración";
            grilla_5.Columns[23].HeaderText = "Teléfono Calibración";
            grilla_5.Columns[24].HeaderText = "Email Calibración";
            grilla_5.Columns[25].HeaderText = "Nombre Calibración";

            //Ejecucion en postgresql
            grilla_5.Rows.Clear();
            NpgsqlCommand sme = new NpgsqlCommand();
            sme.CommandText = " SELECT * FROM datos_proveedor WHERE n5_serie = '" + serie_busqueda.Text + "';";
            sme.Connection = cn;
            NpgsqlDataReader de = sme.ExecuteReader();
            while (de.Read())
            {
                grilla_5.Rows.Add(de[0], de[1], de[2], de[3], de[4], de[5], de[6], de[7], de[8], de[9], de[10], de[11], de[12], de[13], de[14], de[15], de[16], de[17], de[18], de[19], de[20], de[21], de[22], de[23], de[24],de[25]);
            }
            de.Close();

            //PARTE 5: Cargar los datos de la REQUERIMENTOS DE FUNCIONAMIENTO

            grilla_6.ColumnCount = 30;
            grilla_6.Columns[0].HeaderText = "Numero de Serie";
            grilla_6.Columns[1].HeaderText = "Tipo de registro";
            grilla_6.Columns[2].HeaderText = "Eléctrico";
            grilla_6.Columns[3].HeaderText = "Medición: Eléctrico";
            grilla_6.Columns[4].HeaderText = "Mecánico";
            grilla_6.Columns[5].HeaderText = "Medición: Mecánico";
            grilla_6.Columns[6].HeaderText = "Electrónico";
            grilla_6.Columns[7].HeaderText = "Medición: Electrónico";
            grilla_6.Columns[8].HeaderText = "Hidraúlico";
            grilla_6.Columns[9].HeaderText = "Medición: Hidraúlico";
            grilla_6.Columns[10].HeaderText = "Neumático";
            grilla_6.Columns[11].HeaderText = "Medición: Neumático";
            grilla_6.Columns[12].HeaderText = "Electromecánico";
            grilla_6.Columns[13].HeaderText = "Medición: Electromecánico";
            grilla_6.Columns[14].HeaderText = "Vapor";
            grilla_6.Columns[15].HeaderText = "Medición: Vapor";
            grilla_6.Columns[16].HeaderText = "GLP";
            grilla_6.Columns[17].HeaderText = "Medición: GLP";
            grilla_6.Columns[18].HeaderText = "Gases Medicinales";
            grilla_6.Columns[19].HeaderText = "Medición: Gases Medicinales";
            grilla_6.Columns[20].HeaderText = "Aire Comprimido";
            grilla_6.Columns[21].HeaderText = "Medición: Aire Comprimido";
            grilla_6.Columns[22].HeaderText = "Agua Fría";
            grilla_6.Columns[23].HeaderText = "Medición: Agua Fría";
            grilla_6.Columns[24].HeaderText = "Agua Caliente";
            grilla_6.Columns[25].HeaderText = "Medición: Agua Caliente";
            grilla_6.Columns[26].HeaderText = "Agua Descalcificada";
            grilla_6.Columns[27].HeaderText = "Medición: Agua Descalcificada";
            grilla_6.Columns[28].HeaderText = "Otro";
            grilla_6.Columns[29].HeaderText = "Estatus: Otro";

            //Ejecucion en postgresql
            grilla_6.Rows.Clear();
            NpgsqlCommand smf = new NpgsqlCommand();
            smf.CommandText = " SELECT * FROM equip_requirements WHERE n1_serie = '" + serie_busqueda.Text + "';";
            smf.Connection = cn;
            NpgsqlDataReader df = smf.ExecuteReader();
            while (df.Read())
            {
                grilla_6.Rows.Add(df[0], df[1], df[2], df[3], df[4], df[5], df[6], df[7], df[8], df[9], df[10], df[11], df[12], df[13], df[14], df[15], df[16], df[17], df[18], df[19], df[20], df[21], df[22], df[23], df[24], df[25], df[26], df[27], df[28],df[29]);
            }
            df.Close();

            //PARTE 6: Cargar los datos de la PARAMETROS MEDIDOS/TRANSMITIDOS

            grilla_7.ColumnCount = 29;
            grilla_7.Columns[0].HeaderText = "Numero de Serie";
            grilla_7.Columns[1].HeaderText = "Tipo Registro";
            grilla_7.Columns[2].HeaderText = "ECG";
            grilla_7.Columns[3].HeaderText = "SPO2";
            grilla_7.Columns[4].HeaderText = "F.CARDIACA";
            grilla_7.Columns[5].HeaderText = "EEG";
            grilla_7.Columns[6].HeaderText = "SPCO";
            grilla_7.Columns[7].HeaderText = "CO";
            grilla_7.Columns[8].HeaderText = "02";
            grilla_7.Columns[9].HeaderText = "APNEA";
            grilla_7.Columns[10].HeaderText = "TEMPERATURA";
            grilla_7.Columns[11].HeaderText = "F.CEREBRAL";
            grilla_7.Columns[12].HeaderText = "F.RESPIRATORIA";
            grilla_7.Columns[13].HeaderText = "PRESION INVASIVA";
            grilla_7.Columns[14].HeaderText = "ARRITMIA";
            grilla_7.Columns[15].HeaderText = "PRESION NO INVASIVA";
            grilla_7.Columns[16].HeaderText = "PH";
            grilla_7.Columns[17].HeaderText = "MASA";
            grilla_7.Columns[18].HeaderText = "PIC ";
            grilla_7.Columns[19].HeaderText = "BIS ";
            grilla_7.Columns[20].HeaderText = "VCV ";
            grilla_7.Columns[21].HeaderText = "PVC";
            grilla_7.Columns[22].HeaderText = "SIMV";
            grilla_7.Columns[23].HeaderText = "PEEP";
            grilla_7.Columns[24].HeaderText = "PSV";
            grilla_7.Columns[25].HeaderText = "MAC";
            grilla_7.Columns[26].HeaderText = "NO2";
            grilla_7.Columns[27].HeaderText = "FIO2";
            grilla_7.Columns[28].HeaderText = "Otro";

            //Ejecucion en postgresql
            grilla_7.Rows.Clear();
            NpgsqlCommand smg = new NpgsqlCommand();
            smg.CommandText = " SELECT * FROM equip_parameters WHERE n2_serie = '" + serie_busqueda.Text + "';";
            smg.Connection = cn;
            NpgsqlDataReader dg = smg.ExecuteReader();
            while (dg.Read())
            {
                grilla_7.Rows.Add(dg[0], dg[1], dg[2], dg[3], dg[4], dg[5], dg[6], dg[7], dg[8], dg[9], dg[10], dg[11], dg[12], dg[13], dg[14], dg[15], dg[16], dg[17], dg[18], dg[19], dg[20], dg[21], dg[22], dg[23], dg[24], dg[25], dg[26],dg[27],dg[28]);
            }
            dg.Close();

            //PARTE 6: Cargar los datos de la INFORMACIÓN TÉCNICA
            
            grilla_8.ColumnCount = 8;
            grilla_8.Columns[0].HeaderText = "Número de Serie";
            grilla_8.Columns[1].HeaderText = "Tipo de Registro";
            grilla_8.Columns[2].HeaderText = "Manual de operación";
            grilla_8.Columns[3].HeaderText = "Manual de instalación";
            grilla_8.Columns[4].HeaderText = "Manual de servicio";
            grilla_8.Columns[5].HeaderText = "Manual de partes";
            grilla_8.Columns[6].HeaderText = "Otra literatura";
            grilla_8.Columns[7].HeaderText = "No existe información técnica";

            //Ejecucion en postgresql
            grilla_8.Rows.Clear();
            NpgsqlCommand smh = new NpgsqlCommand();
            smh.CommandText = " SELECT * FROM info_tecnica WHERE n6_serie = '" + serie_busqueda.Text + "';";
            smh.Connection = cn;
            NpgsqlDataReader dh = smh.ExecuteReader();
            while (dh.Read())
            {
                grilla_8.Rows.Add(dh[0], dh[1], dh[2], dh[3], dh[4], dh[5], dh[6],dh[7]);
            }
            dh.Close();


            //PARTE 7: Cargar los datos de la ESTADO BIEN

            grilla_9.ColumnCount = 5;
            grilla_9.Columns[0].HeaderText = "Número de Serie";
            grilla_9.Columns[1].HeaderText = "Tipo de Registro";
            grilla_9.Columns[2].HeaderText = "Estatus";
            grilla_9.Columns[3].HeaderText = "No operativo: Estatus";
            grilla_9.Columns[4].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_9.Rows.Clear();
            NpgsqlCommand smi = new NpgsqlCommand();
            smi.CommandText = " SELECT * FROM estado_bien WHERE n7_serie = '" + serie_busqueda.Text + "';";
            smi.Connection = cn;
            NpgsqlDataReader di = smi.ExecuteReader();
            while (di.Read())
            {
                grilla_9.Rows.Add(di[0], di[1], di[2], di[3],di[4]);
            }
            di.Close();

            //PARTE 8: ACCESORIOS DEL EQUIPO

            grilla_10.ColumnCount = 15;
            grilla_10.Columns[0].HeaderText = "Número de Serie";
            grilla_10.Columns[1].HeaderText = "Tipo de Registro";
            grilla_10.Columns[2].HeaderText = "1er Accesorio";
            grilla_10.Columns[3].HeaderText = "2do Accesorio";
            grilla_10.Columns[4].HeaderText = "3er Accesorio";
            grilla_10.Columns[5].HeaderText = "4to Accesorio";
            grilla_10.Columns[6].HeaderText = "5to Accesorio";
            grilla_10.Columns[7].HeaderText = "6to Accesorio";
            grilla_10.Columns[8].HeaderText = "Estado 1er Accesorio";
            grilla_10.Columns[9].HeaderText = "Estado 2do Accesorio";
            grilla_10.Columns[10].HeaderText = "Estado 3er Accesorio";
            grilla_10.Columns[11].HeaderText = "Estado 4to Accesorio";
            grilla_10.Columns[12].HeaderText = "Estado 5to Accesorio";
            grilla_10.Columns[13].HeaderText = "Estado 6to Accesorio";
            grilla_10.Columns[14].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_10.Rows.Clear();
            NpgsqlCommand smj = new NpgsqlCommand();
            smj.CommandText = " SELECT * FROM accesorio_equipo WHERE n8_serie = '" + serie_busqueda.Text + "';";
            smj.Connection = cn;
            NpgsqlDataReader dj = smj.ExecuteReader();
            while (dj.Read())
            {
                grilla_10.Rows.Add(dj[0], dj[1], dj[2], dj[3], dj[4], dj[5], dj[6], dj[7], dj[8], dj[9], dj[10], dj[11], dj[12], dj[13],dj[14]);
            }
            dj.Close();

            //PARTE 9: OTROS DATOS

            grilla_11.ColumnCount = 7;
            grilla_11.Columns[0].HeaderText = "Número de Serie";
            grilla_11.Columns[1].HeaderText = "Tipo de Registro";
            grilla_11.Columns[2].HeaderText = "Garantía";
            grilla_11.Columns[3].HeaderText = "Contrato";
            grilla_11.Columns[4].HeaderText = "Frecuencia MTTO";
            grilla_11.Columns[5].HeaderText = "Responsable MTTO";
            grilla_11.Columns[6].HeaderText = "Observaciones";

            //Ejecucion en postgresql
            grilla_11.Rows.Clear();
            NpgsqlCommand smk = new NpgsqlCommand();
            smk.CommandText = " SELECT * FROM otros_datos WHERE n9_serie = '" + serie_busqueda.Text + "';";
            smk.Connection = cn;
            NpgsqlDataReader dk = smk.ExecuteReader();
            while (dk.Read())
            {
                grilla_11.Rows.Add(dk[0], dk[1], dk[2], dk[3], dk[4], dk[5],dk[6]);
            }
            dk.Close();

            //PARTE 9: Registro de Elaboración y Actualización

            grilla_12.ColumnCount = 8;
            grilla_12.Columns[0].HeaderText = "Número de Serie";
            grilla_12.Columns[1].HeaderText = "Tipo de Registro";
            grilla_12.Columns[2].HeaderText = "Nombre Responsable";
            grilla_12.Columns[3].HeaderText = "Cargo";
            grilla_12.Columns[4].HeaderText = "Teléfono";
            grilla_12.Columns[5].HeaderText = "Email";
            grilla_12.Columns[6].HeaderText = "Fecha";
            grilla_12.Columns[7].HeaderText = "Firma";

            //Ejecucion en postgresql
            grilla_12.Rows.Clear();
            NpgsqlCommand sml = new NpgsqlCommand();
            sml.CommandText = " SELECT * FROM registro_elab WHERE n10_serie = '" + serie_busqueda.Text + "';";
            sml.Connection = cn;
            NpgsqlDataReader dl = sml.ExecuteReader();
            while (dl.Read())
            {
                grilla_12.Rows.Add(dl[0], dl[1], dl[2], dl[3], dl[4], dl[5], dl[6], dl[7]);
            }
            dl.Close();

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {
            
        }

        private void grilla_6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void grilla_10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void grilla_12_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void grilla_3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grilla_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            //equipo description 
            DatosInforme.equip_descriptionD["tipo_bien"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.equip_descriptionD["Nombre_equipo"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.equip_descriptionD["Marca"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.equip_descriptionD["Modelo"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.equip_descriptionD["Serie"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.equip_descriptionD["tipo_registro"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.equip_descriptionD["fab_year"] = desp_bien_busqueda.Rows[e.RowIndex].Cells[6].Value.ToString();

        
            //equip_tdata
            DatosInforme.equipo_tdata["n_serie"] = grilla_2.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.equipo_tdata["n_tipo_registro"] = grilla_2.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.equipo_tdata["vol"] = grilla_2.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.equipo_tdata["fase"] = grilla_2.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.equipo_tdata["corriente"] = grilla_2.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.equipo_tdata["potencia"] = grilla_2.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.equipo_tdata["frecuencia"] = grilla_2.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.equipo_tdata["bateria"] = grilla_2.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.equipo_tdata["channels"] = grilla_2.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.equipo_tdata["memory"] = grilla_2.Rows[e.RowIndex].Cells[9].Value.ToString();
            DatosInforme.equipo_tdata["printer"] = grilla_2.Rows[e.RowIndex].Cells[10].Value.ToString();
            DatosInforme.equipo_tdata["observaciones"] = grilla_2.Rows[e.RowIndex].Cells[11].Value.ToString();

            //equip_requirements
            DatosInforme.equipo_requirements["n1_serie"] = grilla_6.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.equipo_requirements["n1_tipo_registro"] = grilla_6.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.equipo_requirements["electrico"] = grilla_6.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.equipo_requirements["med_electrico"] = grilla_6.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.equipo_requirements["mecanico"] = grilla_6.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.equipo_requirements["med_mecanico"] = grilla_6.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.equipo_requirements["electronico"] = grilla_6.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.equipo_requirements["med_electronico"] = grilla_6.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.equipo_requirements["hidraulico"] = grilla_6.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.equipo_requirements["med_hidraulico"] = grilla_6.Rows[e.RowIndex].Cells[9].Value.ToString();
            DatosInforme.equipo_requirements["neumatico"] = grilla_6.Rows[e.RowIndex].Cells[10].Value.ToString();
            DatosInforme.equipo_requirements["med_neumatico"] = grilla_6.Rows[e.RowIndex].Cells[11].Value.ToString();
            DatosInforme.equipo_requirements["electromicanico"] = grilla_6.Rows[e.RowIndex].Cells[12].Value.ToString();
            DatosInforme.equipo_requirements["med_electromicanico"] = grilla_6.Rows[e.RowIndex].Cells[13].Value.ToString();
            DatosInforme.equipo_requirements["vapor"] = grilla_6.Rows[e.RowIndex].Cells[14].Value.ToString();
            DatosInforme.equipo_requirements["med_vapor"] = grilla_6.Rows[e.RowIndex].Cells[15].Value.ToString();
            DatosInforme.equipo_requirements["glp"] = grilla_6.Rows[e.RowIndex].Cells[16].Value.ToString();
            DatosInforme.equipo_requirements["med_glp"] = grilla_6.Rows[e.RowIndex].Cells[17].Value.ToString();
            DatosInforme.equipo_requirements["medicinal"] = grilla_6.Rows[e.RowIndex].Cells[18].Value.ToString();
            DatosInforme.equipo_requirements["med_medicinal"] = grilla_6.Rows[e.RowIndex].Cells[19].Value.ToString();
            DatosInforme.equipo_requirements["a_comprimido"] = grilla_6.Rows[e.RowIndex].Cells[20].Value.ToString();
            DatosInforme.equipo_requirements["med_a_comprimido"] = grilla_6.Rows[e.RowIndex].Cells[21].Value.ToString();
            DatosInforme.equipo_requirements["a_fria"] = grilla_6.Rows[e.RowIndex].Cells[22].Value.ToString();
            DatosInforme.equipo_requirements["med_a_fria"] = grilla_6.Rows[e.RowIndex].Cells[23].Value.ToString();
            DatosInforme.equipo_requirements["a_caliente"] = grilla_6.Rows[e.RowIndex].Cells[24].Value.ToString();
            DatosInforme.equipo_requirements["med_a_caliente"] = grilla_6.Rows[e.RowIndex].Cells[25].Value.ToString();
            DatosInforme.equipo_requirements["a_descal"] = grilla_6.Rows[e.RowIndex].Cells[26].Value.ToString();
            DatosInforme.equipo_requirements["med_a_descal"] = grilla_6.Rows[e.RowIndex].Cells[27].Value.ToString();
            DatosInforme.equipo_requirements["otro"] = grilla_6.Rows[e.RowIndex].Cells[28].Value.ToString();
            DatosInforme.equipo_requirements["med_otro"] = grilla_6.Rows[e.RowIndex].Cells[29].Value.ToString();

            //equip_parameters
            DatosInforme.equipo_parameters["n2_serie"] = grilla_7.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.equipo_parameters["n2_tipo_registro"] = grilla_7.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.equipo_parameters["ecg"] = grilla_7.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.equipo_parameters["spo2"] = grilla_7.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.equipo_parameters["f_cardiaca"] = grilla_7.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.equipo_parameters["eeg"] = grilla_7.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.equipo_parameters["spco"] = grilla_7.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.equipo_parameters["co"] = grilla_7.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.equipo_parameters["o2"] = grilla_7.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.equipo_parameters["apnea"] = grilla_7.Rows[e.RowIndex].Cells[9].Value.ToString();
            DatosInforme.equipo_parameters["temperatura"] = grilla_7.Rows[e.RowIndex].Cells[10].Value.ToString();
            DatosInforme.equipo_parameters["f_cerebral"] = grilla_7.Rows[e.RowIndex].Cells[11].Value.ToString();
            DatosInforme.equipo_parameters["f_respiratoria"] = grilla_7.Rows[e.RowIndex].Cells[12].Value.ToString();
            DatosInforme.equipo_parameters["p_invasiva"] = grilla_7.Rows[e.RowIndex].Cells[13].Value.ToString();
            DatosInforme.equipo_parameters["arritmia"] = grilla_7.Rows[e.RowIndex].Cells[14].Value.ToString();
            DatosInforme.equipo_parameters["p_ninvasia"] = grilla_7.Rows[e.RowIndex].Cells[15].Value.ToString();
            DatosInforme.equipo_parameters["ph"] = grilla_7.Rows[e.RowIndex].Cells[16].Value.ToString();
            DatosInforme.equipo_parameters["masa"] = grilla_7.Rows[e.RowIndex].Cells[17].Value.ToString();
            DatosInforme.equipo_parameters["pic"] = grilla_7.Rows[e.RowIndex].Cells[18].Value.ToString();
            DatosInforme.equipo_parameters["bis"] = grilla_7.Rows[e.RowIndex].Cells[19].Value.ToString();
            DatosInforme.equipo_parameters["vcv"] = grilla_7.Rows[e.RowIndex].Cells[20].Value.ToString();
            DatosInforme.equipo_parameters["pcv"] = grilla_7.Rows[e.RowIndex].Cells[21].Value.ToString();
            DatosInforme.equipo_parameters["simv"] = grilla_7.Rows[e.RowIndex].Cells[22].Value.ToString();
            DatosInforme.equipo_parameters["peep"] = grilla_7.Rows[e.RowIndex].Cells[23].Value.ToString();
            DatosInforme.equipo_parameters["psv"] = grilla_7.Rows[e.RowIndex].Cells[24].Value.ToString();
            DatosInforme.equipo_parameters["mac"] = grilla_7.Rows[e.RowIndex].Cells[25].Value.ToString();
            DatosInforme.equipo_parameters["no2"] = grilla_7.Rows[e.RowIndex].Cells[26].Value.ToString();
            DatosInforme.equipo_parameters["fio2"] = grilla_7.Rows[e.RowIndex].Cells[27].Value.ToString();
            DatosInforme.equipo_parameters["otro"] = grilla_7.Rows[e.RowIndex].Cells[28].Value.ToString();

            //datos economicos
            DatosInforme.datos_economicos["n3_serie"] = grilla_3.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.datos_economicos["n3_tipo_registro"] = grilla_3.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.datos_economicos["valor_adq"] = grilla_3.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.datos_economicos["n_factura"] = grilla_3.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.datos_economicos["f_adquisicion"] = grilla_3.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.datos_economicos["fecha"] = grilla_3.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.datos_economicos["vida_util"] = grilla_3.Rows[e.RowIndex].Cells[6].Value.ToString();

            //ubicacion equipo
        
            DatosInforme.ubicacion_equipo["n4_serie"] = grilla_4.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.ubicacion_equipo["n4_tipo_registro"] = grilla_4.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.ubicacion_equipo["unidad_op"] = grilla_4.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.ubicacion_equipo["servicio"] = grilla_4.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.ubicacion_equipo["sub_servicio"] = grilla_4.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.ubicacion_equipo["nombre_custodio"] = grilla_4.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.ubicacion_equipo["zona"] = grilla_4.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.ubicacion_equipo["distrito"] = grilla_4.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.ubicacion_equipo["provincia"] = grilla_4.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.ubicacion_equipo["ciudad"] = grilla_4.Rows[e.RowIndex].Cells[9].Value.ToString();

            //informacion provedor
            DatosInforme.datos_proveedor["n5_serie"] = grilla_5.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.datos_proveedor["n5_tipo_registro"] = grilla_5.Rows[e.RowIndex].Cells[1].Value.ToString();

            DatosInforme.datos_proveedor["fabricante"] = grilla_5.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.datos_proveedor["direccion_fab"] = grilla_5.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.datos_proveedor["telefono_fab"] = grilla_5.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.datos_proveedor["email_fab"] = grilla_5.Rows[e.RowIndex].Cells[5].Value.ToString();

            DatosInforme.datos_proveedor["provedor"] = grilla_5.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.datos_proveedor["direccion_prov"] = grilla_5.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.datos_proveedor["telefono_prov"] = grilla_5.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.datos_proveedor["email_prov"] = grilla_5.Rows[e.RowIndex].Cells[9].Value.ToString();
            DatosInforme.datos_proveedor["nombre_prov_cont"] = grilla_5.Rows[e.RowIndex].Cells[10].Value.ToString();

            DatosInforme.datos_proveedor["representante_pais"] = grilla_5.Rows[e.RowIndex].Cells[11].Value.ToString();
            DatosInforme.datos_proveedor["direccion_rep"] = grilla_5.Rows[e.RowIndex].Cells[12].Value.ToString();
            DatosInforme.datos_proveedor["telefono_rep"] = grilla_5.Rows[e.RowIndex].Cells[13].Value.ToString();
            DatosInforme.datos_proveedor["email_rep"] = grilla_5.Rows[e.RowIndex].Cells[14].Value.ToString();
            DatosInforme.datos_proveedor["nombre_rep"] = grilla_5.Rows[e.RowIndex].Cells[15].Value.ToString();

            DatosInforme.datos_proveedor["prov_manten"] = grilla_5.Rows[e.RowIndex].Cells[16].Value.ToString();
            DatosInforme.datos_proveedor["direccion_mant"] = grilla_5.Rows[e.RowIndex].Cells[17].Value.ToString();
            DatosInforme.datos_proveedor["telefono_mant"] = grilla_5.Rows[e.RowIndex].Cells[18].Value.ToString();
            DatosInforme.datos_proveedor["email_mant"] = grilla_5.Rows[e.RowIndex].Cells[19].Value.ToString();
            DatosInforme.datos_proveedor["nombre_mant"] = grilla_5.Rows[e.RowIndex].Cells[20].Value.ToString();

            DatosInforme.datos_proveedor["prov_calib"] = grilla_5.Rows[e.RowIndex].Cells[21].Value.ToString();
            DatosInforme.datos_proveedor["direccion_calib"] = grilla_5.Rows[e.RowIndex].Cells[22].Value.ToString();
            DatosInforme.datos_proveedor["telefono_calib"] = grilla_5.Rows[e.RowIndex].Cells[23].Value.ToString();
            DatosInforme.datos_proveedor["email_calib"] = grilla_5.Rows[e.RowIndex].Cells[24].Value.ToString();
            DatosInforme.datos_proveedor["nombre_calib"] = grilla_5.Rows[e.RowIndex].Cells[25].Value.ToString();

            //info tecnica
            DatosInforme.info_tecnica["n6_serie"] = grilla_8.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.info_tecnica["n6_tipo_registro"] = grilla_8.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.info_tecnica["manual_op"] = grilla_8.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.info_tecnica["manual_inst"] = grilla_8.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.info_tecnica["manual_servi"] = grilla_8.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.info_tecnica["manual_part"] = grilla_8.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.info_tecnica["otra_lit"] = grilla_8.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.info_tecnica["no_existe"] = grilla_8.Rows[e.RowIndex].Cells[7].Value.ToString();

            //estado bien
            DatosInforme.estado_bien["n7_serie"] = grilla_9.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.estado_bien["n7_tipo_registro"] = grilla_9.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.estado_bien["status"] = grilla_9.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.estado_bien["no_operativo"] = grilla_9.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.estado_bien["observaciones"] = grilla_9.Rows[e.RowIndex].Cells[4].Value.ToString();

            //accesorios equipo
            DatosInforme.accesorio_equipo["n8_serie"] = grilla_10.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.accesorio_equipo["n8_tipo_registro"] = grilla_10.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.accesorio_equipo["primero"] = grilla_10.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.accesorio_equipo["segundo"] = grilla_10.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.accesorio_equipo["tercero"] = grilla_10.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.accesorio_equipo["cuarto"] = grilla_10.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.accesorio_equipo["quinto"] = grilla_10.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.accesorio_equipo["sexto"] = grilla_10.Rows[e.RowIndex].Cells[7].Value.ToString();
            DatosInforme.accesorio_equipo["estado_pr"] = grilla_10.Rows[e.RowIndex].Cells[8].Value.ToString();
            DatosInforme.accesorio_equipo["estado_se"] = grilla_10.Rows[e.RowIndex].Cells[9].Value.ToString();
            DatosInforme.accesorio_equipo["estado_te"] = grilla_10.Rows[e.RowIndex].Cells[10].Value.ToString();
            DatosInforme.accesorio_equipo["estado_cu"] = grilla_10.Rows[e.RowIndex].Cells[11].Value.ToString();
            DatosInforme.accesorio_equipo["estado_qu"] = grilla_10.Rows[e.RowIndex].Cells[12].Value.ToString();
            DatosInforme.accesorio_equipo["estado_sex"] = grilla_10.Rows[e.RowIndex].Cells[13].Value.ToString();
            DatosInforme.accesorio_equipo["observaciones"] = grilla_10.Rows[e.RowIndex].Cells[14].Value.ToString();

            //otros datos
            DatosInforme.otros_datos["n9_serie"] = grilla_11.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.otros_datos["n9_tipo_registro"] = grilla_11.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.otros_datos["garantia"] = grilla_11.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.otros_datos["contrato"] = grilla_11.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.otros_datos["frecuencia"] = grilla_11.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.otros_datos["responsable"] = grilla_11.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.otros_datos["observaciones"] = grilla_11.Rows[e.RowIndex].Cells[6].Value.ToString();

            //registro_elab
            DatosInforme.registro_elab["n10_serie"] = grilla_12.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosInforme.registro_elab["n10_tipo_registro"] = grilla_12.Rows[e.RowIndex].Cells[1].Value.ToString();
            DatosInforme.registro_elab["nombre_resp"] = grilla_12.Rows[e.RowIndex].Cells[2].Value.ToString();
            DatosInforme.registro_elab["cargo"] = grilla_12.Rows[e.RowIndex].Cells[3].Value.ToString();
            DatosInforme.registro_elab["telefono"] = grilla_12.Rows[e.RowIndex].Cells[4].Value.ToString();
            DatosInforme.registro_elab["email"] = grilla_12.Rows[e.RowIndex].Cells[5].Value.ToString();
            DatosInforme.registro_elab["fecha"] = grilla_12.Rows[e.RowIndex].Cells[6].Value.ToString();
            DatosInforme.registro_elab["firmar"] = grilla_12.Rows[e.RowIndex].Cells[7].Value.ToString();
      
            BusquedaInforme formulario = new BusquedaInforme();
            formulario.Show();
        }
    }
}

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
using System.Net.Mail;
using System.Configuration;
//using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


namespace Dispositivos
{
    public partial class Hoja_de_vida : Form
    {

        NpgsqlConnection cn;

        const string Usuario = "jhonndiegoo@gmail.com"; 
        const string Password = "ubuntulinux135";
        public Hoja_de_vida()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void Hoja_de_vida_Load(object sender, EventArgs e)
        {
            
        //restricciones longuitud cuadros de texto
            //equip_description 
            year.MaxLength = 4;
            marca.MaxLength = 15;
            modelo.MaxLength = 30;
            //datos tecnicos
            memory.MaxLength = 15;
            printer.MaxLength = 15;
            //datos econimicos
            valor_adq.MaxLength = 15;
            vida_util.MaxLength = 10;

            //ubicacion del equipo 
            nombre_custodio.MaxLength = 20;

            //datos provedor
            fabricante.MaxLength = 40;
            direccion_fab.MaxLength = 60;
            telefono_fab.MaxLength = 10;
            email_fab.MaxLength = 30;

            proveedor.MaxLength = 40;
            direccion_prov.MaxLength = 60;
            telefono_prov.MaxLength = 10;
            email_prov.MaxLength = 30;

            nombre_prov.MaxLength = 40;
            repre_pais.MaxLength = 40;
            direccion_rep.MaxLength = 60;
            telefono_rep.MaxLength = 10;
            email_rep.MaxLength = 30;
            nombre_rep.MaxLength = 40;

            prov_mant.MaxLength = 40;
            direccion_mant.MaxLength = 30;
            telefono_mant.MaxLength = 10;
            email_mant.MaxLength = 30;
            nombre_mant.MaxLength = 40;
            prov_calib.MaxLength = 40;
            direccion_calib.MaxLength = 60;
            telefono_calib.MaxLength = 10;
            email_calib.MaxLength = 30;
            nombre_calib.MaxLength = 40;

            //requermientos de equipo
            m_electrico.MaxLength = 40;
            m_mecanico.MaxLength = 40;
            m_hidraulico.MaxLength = 40;
            m_neumatico.MaxLength = 40;
            m_electromecanico.MaxLength = 40;
            m_vapor.MaxLength = 40;
            m_glp.MaxLength = 40;
            m_gases_medicinales.MaxLength = 40;
            m_aire_comp.MaxLength = 40; 
            m_agua_fria.MaxLength = 40;
            m_agua_caliente.MaxLength = 40;
            m_agua_descalcificada.MaxLength = 40;
            m_otro.MaxLength = 40;

            //estado del bien
            obs_estatus.MaxLength = 60;

            //accesorio equipo
            primero.MaxLength = 60;
            segundo.MaxLength = 60;
            tercero.MaxLength = 60;
            cuarto.MaxLength = 60;
            quinto.MaxLength = 60;
            sexto.MaxLength = 60;
            obs_accesorios.MaxLength = 60;

            //registro elaboracion y actualizacion
            nombre_resp.MaxLength = 30;
            cargo_resp.MaxLength = 30;
            telefono_resp.MaxLength = 10;
            email_resp.MaxLength = 30;

            //cargar datos y desactivar cajas de texto
            Desbloquear_bloquear(false);
            tipo_registro_valor.ReadOnly = true;

            


            //anadir a combo box
            provincia.Items.Add("Azuay"); provincia.Items.Add("Bolivar"); provincia.Items.Add("Cañar");
            provincia.Items.Add("Carchi"); provincia.Items.Add("Chimborazo"); provincia.Items.Add("Cotopaxi");
            provincia.Items.Add("El Oro"); provincia.Items.Add("Esmeraldas"); provincia.Items.Add("Galápagos");
            provincia.Items.Add("Guayanas"); provincia.Items.Add("Loja"); provincia.Items.Add("Los Ríos");
            provincia.Items.Add("Manabí"); provincia.Items.Add("Morona Santiago"); provincia.Items.Add("Napo");
            provincia.Items.Add("Sucumbíos"); provincia.Items.Add("Pastaza"); provincia.Items.Add("Pinchincha");
            provincia.Items.Add("Santa Elena"); provincia.Items.Add("Santo Domingo"); provincia.Items.Add("Francisco De Orellana");
            provincia.Items.Add("Tungurahua"); provincia.Items.Add("Zamora Chinchipe");

            ciudad.Items.Add("Cuenca"); ciudad.Items.Add("Guaranda"); ciudad.Items.Add("Azogues");
            ciudad.Items.Add("Tulcán"); ciudad.Items.Add("Riobamba"); ciudad.Items.Add("Latacunga");
            ciudad.Items.Add("Machala"); ciudad.Items.Add("Ciudad Esmeraldas"); ciudad.Items.Add("Puerto Baquerizo Moreno");
            ciudad.Items.Add("Guayaquil"); ciudad.Items.Add("Loja"); ciudad.Items.Add("Babahoyo");
            ciudad.Items.Add("Portoviejo"); ciudad.Items.Add("Macas"); ciudad.Items.Add("Tena");
            ciudad.Items.Add("Francisco de Orellana"); ciudad.Items.Add("Puyo"); ciudad.Items.Add("Quito");
            ciudad.Items.Add("Santa Elena"); ciudad.Items.Add("Santo Domingo"); ciudad.Items.Add("Nueva Loja");
            ciudad.Items.Add("Ambato"); ciudad.Items.Add("Zamora");

            tipo_registro.Items.Add("Registro dispositovo");
            tipo_registro.Items.Add("Mantenimiento");
            
            
            
            //Conectar a una base de datos
            //string str = "Server=127.0.0.1;Port=5432;Database=dispositivos-biomedicos;User Id=postgres;Password=hpenvy135;";
            //string str = "Server=127.0.0.1;Port=5432;Database=backup_dispositivos_biomedicos;User Id=postgres;Password=hpenvy135;";
            string str = "Server=127.0.0.1;Port=5432;Database=backup_dispositivos_biomedicos;User Id=postgres;Password=hgsvp;";
            cn = new NpgsqlConnection();
            cn.ConnectionString = str;
            cn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Validar Campos
            BorrarMensajeError();
            if (ValidarCampos())   //ValidarCampos()
            {

                NpgsqlCommand cmd = new NpgsqlCommand();
                
                //Descripcion del equipo
                string str0 = "INSERT INTO equip_description(tipo_bien,nombre,marca,modelo,serie,tipo_registro,fab_year) VALUES ('";
                str0 = str0 + bien.Text + "','" + equipo.Text + "','" + marca.Text + "','" + modelo.Text + "','";
                str0 = str0 + serie.Text + "','" + tipo_registro_valor.Text + "','" + year.Text + "')";
                
                cmd.CommandText = str0;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro DESCRIPCION DEL BIEN ingresado correctamente");
                                       //Limpiar TextBox1

                //Limpiar_campos();
                //Datos del equipo, valores

                string str1 = "Insert into equip_tdata(n_serie,n_tipo_registro,vol,fase,corriente,potencia,frecuencia,bateria,channels,memory,printer,observaciones) values('";
                str1 = str1 + serie.Text + "','" + tipo_registro_valor.Text + "','" + vol.Text + "','" + fase_voltaje.Text + "','" + corriente.Text + "','";
                str1 = str1 + potencia.Text + "','" + frecuencia.Text + "','" + bateria.Text + "','" + channels.Text + "','";
                str1 = str1 + memory.Text + "','" + printer.Text + "','" + observaciones_1.Text + "')";
                cmd.CommandText = str1;
                cmd.Connection = cn;
                //MessageBox.Show(str1.ToString());
                cmd.ExecuteNonQuery(); //se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro DATOS TÉCNICOS ingresado correctamente");
                                       //Cerrar

                
                
                //Datos economicos

                string str3 = "INSERT INTO datos_economicos VALUES ('";
                str3 = str3 + serie.Text + "','" + tipo_registro_valor.Text + "','" + valor_adq.Text + "','" + n_factura.Text + "','" + f_adquisicion.Text + "','";
                str3 = str3 + fecha_economicos.Value + "','" + vida_util.Text + "')";
                cmd.CommandText = str3;
                cmd.Connection = cn;
                
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro DATOS ECONÓMICOS ingresado correctamente");
                                       //Cerrar
                                       //Datos de ubicacion del equipo
               
                string str4 = "INSERT INTO ubicacion_equipo VALUES ('";
                str4 = str4 + serie.Text + "','" + tipo_registro_valor.Text + "','" + unidad_op.Text + "','" + servicio.Text + "','" + sub_servicio.Text + "','";
                str4 = str4 + nombre_custodio.Text + "','" + zona.Text + "','" + distrito.Text + "','" + provincia.Text + "','";
                str4 = str4 + ciudad.Text + "')";
                cmd.CommandText = str4;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro UBICACION DEL EQUIPO ingresado correctamente");
                                       //Cerrar


                //Datos proveedor 

                string str5 = "INSERT INTO datos_proveedor VALUES ('";
                str5 = str5 + serie.Text + "','" + tipo_registro_valor.Text + "','" + fabricante.Text + "','" + direccion_fab.Text + "','" + telefono_fab.Text + "','" + email_fab.Text + "','";
                str5 = str5 + proveedor.Text + "','" + direccion_prov.Text + "','" + telefono_prov.Text + "','" + email_prov.Text + "','" + nombre_prov.Text + "','";
                str5 = str5 + repre_pais.Text + "','" + direccion_rep.Text + "','" + telefono_rep.Text + "','" + email_rep.Text + "','" + nombre_rep.Text + "','";
                str5 = str5 + prov_mant.Text + "','" + direccion_mant.Text + "','" + telefono_mant.Text + "','" + email_mant.Text + "','" + nombre_mant.Text + "','";
                str5 = str5 + prov_calib.Text + "','" + direccion_calib.Text + "','" + telefono_calib.Text + "','" + email_calib.Text + "','" + nombre_calib.Text + "')";
                cmd.CommandText = str5;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro DATOS DE PROVEEDOR ingresado correctamente");
                                       //Cerrar

                // Tercera Tabla Requerimentos de funcionamiento

                string str2 = "INSERT INTO equip_requirements VALUES ('";
                str2 = str2 + serie.Text + "','" + tipo_registro_valor.Text + "','" + electrico.Text + "','" + m_electrico.Text + "','" + mecanico.Text + "','" + m_mecanico.Text + "','";
                str2 = str2 + electronico.Text + "','" + m_electronico.Text + "','" + hidraulico.Text + "','" + m_hidraulico.Text + "','" + neumatico.Text + "','";
                str2 = str2 + m_neumatico.Text + "','" + electromecanico.Text + "','" + m_electromecanico.Text + "','" + vapor.Text + "','" + m_vapor.Text + "','";
                str2 = str2 + glp_1.Text + "','" + m_glp.Text + "','" + gases_medicinales.Text + "','" + m_gases_medicinales.Text + "','" + aire_comp.Text + "','";
                str2 = str2 + m_aire_comp.Text + "','" + agua_fria.Text + "','" + m_agua_fria.Text + "','" + agua_caliente.Text + "','" + m_agua_caliente.Text + "','";
                str2 = str2 + agua_desc.Text + "','" + m_agua_descalcificada.Text + "','" + otro_1.Text + "','" + m_otro.Text + "')";

                cmd.CommandText = str2;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro REQUERIMIENTOS DE FUNCIONAMIENTO ingresado correctamente");
                                       //Cerrar

                // Cuarta tabla PARAMETROS MEDIDOS

                string str = "INSERT INTO equip_parameters VALUES ('";
                str = str + serie.Text + "','" + tipo_registro_valor.Text + "','" + ecg.Text + "','" + spo2.Text + "','" + fcardiaca.Text + "','" + eeg.Text + "','";
                str = str + spco.Text + "','" + co.Text + "','" + o2.Text + "','" + apnea.Text + "','" + temperatura.Text + "','";
                str = str + fcerebral.Text + "','" + frespiratoria.Text + "','" + presioninvasiva.Text + "','" + arritmia.Text + "','" + presionnoinv.Text + "','";
                str = str + ph.Text + "','" + masa.Text + "','" + pic.Text + "','" + bis.Text + "','" + vcv.Text + "','";
                str = str + pcv.Text + "','" + simv.Text + "','" + peep.Text + "','" + psv.Text + "','" + mac.Text + "','";
                str = str + no2.Text + "','" + fio2.Text + "','" + otro_2.Text + "')";

                cmd.CommandText = str;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro PARAMETROS MEDIDOS ingresado correctamente");
                                       //Cerrar

                // Informacion tecnica

                string str6 = "INSERT INTO info_tecnica VALUES ('";
                str6 = str6 + serie.Text + "','" + tipo_registro_valor.Text + "','" + manual_op.Text + "','" + manual_inst.Text + "','" + manual_servi.Text + "','";
                str6 = str6 + manual_part.Text + "','" + otra_lit.Text + "','" + no_existe.Text + "')";

                cmd.CommandText = str6;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro INFORMACION TECNICA ingresado correctamente");
                                       //Cerrar

                //Estado del bien

                string str7 = "INSERT INTO estado_bien VALUES ('";
                str7 = str7 + serie.Text + "','" + tipo_registro_valor.Text + "','" + estatus.Text + "','" + no_operativo.Text + "','" + obs_estatus.Text + "')";

                cmd.CommandText = str7;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro ESTADO DEL BIEN ingresado correctamente");
                                       //Cerrar


                //Accesorios del equipo

                string str8 = "INSERT INTO accesorio_equipo VALUES ('";
                str8 = str8 + serie.Text + "','" + tipo_registro_valor.Text + "','" + primero.Text + "','" + segundo.Text + "','" + tercero.Text + "','";
                str8 = str8 + cuarto.Text + "','" + quinto.Text + "','" + sexto.Text + "','" + estado_pr.Text + "','";
                str8 = str8 + estado_sec.Text + "','" + estado_ter.Text + "','" + estado_cu.Text + "','" + estado_qu.Text + "','";
                str8 = str8 + estado_sexto.Text + "','" + obs_accesorios.Text + "')";

                cmd.CommandText = str8;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro ACCESORIOS DEL EQUIPO ingresado correctamente");
                                       //Cerrar




                //Otros datos Error

                string str9 = "INSERT INTO otros_datos VALUES ('";
                str9 = str9 + serie.Text + "','" + tipo_registro_valor.Text + "','" + garantia.Text + "','" + contrato.Text + "','" + frecuencia.Text + "','";
                str9 = str9 + responsable.Text + "','" + obs_otros.Text + "')";

                cmd.CommandText = str9;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro OTROS DATOS ingresado correctamente");
                                       //Cerrar


                //Elaboracion y actualizacion

                string str10 = "INSERT INTO registro_elab VALUES ('";
                str10 = str10 + serie.Text + "','" + tipo_registro_valor.Text + "','" + nombre_resp.Text + "','" + cargo_resp.Text + "','" + telefono_resp.Text + "','";
                str10 = str10 + email_resp.Text + "','" + fecha_resp.Value + "','" + firma_resp.Text + "')";

                cmd.CommandText = str10;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery(); //Se ejecuta para insert, update and delete
                                       //MessageBox.Show("El registro REGISTRO ELABORACION ingresado correctamente");
                                       //Cerrar
               
                Limpiar_campos();
            }
        }

        // Validación del ingreso de datos, correción de errores 
        private bool ValidarCampos()
        {
            bool ok = true;
            //Parte 1
            if (bien.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bien, "Ingresar bien");

            }

            if (equipo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(equipo, "Ingresar equipo");

            }

            if (marca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(marca, "Ingresar marca");

            }

            if (modelo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(modelo, "Ingresar modelo");

            }

            if (serie.Text == "")
            {
                ok = false;
                errorProvider1.SetError(serie, "Ingresar serie");

            }

            if (year.Text == "")
            {
                ok = false;
                errorProvider1.SetError(year, "Ingresar año");

            }

            //Parte 2
            if (vol.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vol, "Ingresar voltaje");

            }

            if (fase_voltaje.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fase_voltaje, "Ingresar número de fases");

            }

            if (corriente.Text == "")
            {
                ok = false;
                errorProvider1.SetError(corriente, "Ingresar corriente [A]");

            }

            if (potencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(potencia, "Ingresar potencia [W]");

            }

            if (frecuencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frecuencia, "Ingresar frecuencia [Hz]");

            }

            if (bateria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bateria, "Ingresar Batería [V]");

            }

            if (memory.Text == "")
            {
                ok = false;
                errorProvider1.SetError(memory, "Ingresar Memoria");

            }

            if (printer.Text == "")
            {
                ok = false;
                errorProvider1.SetError(printer, "Ingresar Tipo de Impresora");

            }
            //Observaciones se puede evitar

            //if (observaciones_1.Text == "")
            //{
            //    ok = false;
            //   errorProvider1.SetError(observaciones_1, "Ingresar Observaciones");

            //}

            if (channels.Text == "")
            {
                ok = false;
                errorProvider1.SetError(channels, "Ingresar numero de canales");

            }

            //Parte 3

            if (valor_adq.Text == "")
            {
                ok = false;
                errorProvider1.SetError(valor_adq, "Ingresar valor de adquisición");

            }

            if (n_factura.Text == "")
            {
                ok = false;
                errorProvider1.SetError(n_factura, "Ingresar numero de factura");

            }

            if (f_adquisicion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(f_adquisicion, "Ingresar forma de adquisición");

            }

            if (fecha_economicos.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fecha_economicos, "Ingresar fecha de adquisición");

            }

            if (vida_util.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vida_util, "Ingresar vida util");

            }

            //Parte 4
            if (unidad_op.Text == "")
            {
                ok = false;
                errorProvider1.SetError(unidad_op, "Ingresar unidad operacional");

            }
            if (servicio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(servicio, "Ingresar servicio");

            }
            if (sub_servicio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(sub_servicio, "Ingresar sub servicio");

            }
            if (nombre_custodio.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_custodio, "Ingresar nombre custodio");

            }
            if (zona.Text == "")
            {
                ok = false;
                errorProvider1.SetError(zona, "Ingresar zona");

            }
            if (distrito.Text == "")
            {
                ok = false;
                errorProvider1.SetError(distrito, "Ingresar distrito");

            }
            if (provincia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(provincia, "Ingresar provincia");

            }
            if (ciudad.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ciudad, "Ingresar ciudad");

            }

            //Parte 5
            if (fabricante.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fabricante, "Ingresar fabricante");

            }
            if (direccion_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_fab, "Ingresar direccion fabricante");

            }
            if (telefono_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_fab, "Ingresar telefono fabricante");

            }
            if (email_fab.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_fab, "Ingresar email fabricante");

            }
            if (proveedor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(proveedor, "Ingresar proveedor");

            }
            if (direccion_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_prov, "Ingresar direccion proveedor");

            }
            if (telefono_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_prov, "Ingresar teléfono proveedor");

            }
            if (email_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_prov, "Ingresar email proveedor");

            }
            if (nombre_prov.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_prov, "Ingresar nombre proveedor");

            }
            if (repre_pais.Text == "")
            {
                ok = false;
                errorProvider1.SetError(repre_pais, "Ingresar representante pais");

            }
            if (direccion_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_rep, "Ingresar direccion representante");

            }
            if (telefono_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_rep, "Ingresar telefono representante");

            }
            if (email_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_rep, "Ingresar email representante");

            }
            if (nombre_rep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_rep, "Ingresar nombre representante");

            }
            if (prov_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(prov_mant, "Ingresar proveedor mantenimiento");

            }
            if (direccion_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_mant, "Ingresar direccion mantenimiento");

            }
            if (telefono_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_mant, "Ingresar teléfono mantenimiento");

            }
            if (email_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_mant, "Ingresar email mantenimiento");

            }
            if (nombre_mant.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_mant, "Ingresar nombre mantenimiento");

            }
            if (prov_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(prov_calib, "Ingresar proveedor calibración");

            }
            if (direccion_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(direccion_calib, "Ingresar direccion calibración");

            }
            if (telefono_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_calib, "Ingresar telefono calibración");

            }
            if (email_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_calib, "Ingresar email calibración");
            }
            if (nombre_calib.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_calib, "Ingresar nombre calibración");
            }

            //Pestaña 2
            // Parte 6
            if (electrico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electrico, "Ingresar estatus eléctrico");
            }

            if (mecanico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(mecanico, "Ingresar estatus mecánico");
            }
            if (electronico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electronico, "Ingresar estatus electrónico");
            }
            if (hidraulico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(hidraulico, "Ingresar estatus hidraulico");
            }
            if (neumatico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(neumatico, "Ingresar estatus neumático");
            }
            if (electromecanico.Text == "")
            {
                ok = false;
                errorProvider1.SetError(electromecanico, "Ingresar estatus electromecánico");
            }
            if (vapor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vapor, "Ingresar estatus vapor");
            }
            if (glp_1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(glp_1, "Ingresar estatus glp");
            }
            if (gases_medicinales.Text == "")
            {
                ok = false;
                errorProvider1.SetError(gases_medicinales, "Ingresar estatus gases medicinales");
            }
            if (aire_comp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(aire_comp, "Ingresar estatus aire comprimido");
            }
            if (agua_fria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_fria, "Ingresar estatus agua fría");
            }
            if (agua_caliente.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_caliente, "Ingresar estatus agua caliente");
            }
            if (agua_desc.Text == "")
            {
                ok = false;
                errorProvider1.SetError(agua_desc, "Ingresar estatus agua descalcificada");
            }
            if (otro_1.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otro_1, "Ingresar estatus otro");
            }
            //Parte 7
            if (ecg.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ecg, "Ingresar ecg");
            }
            if (spo2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(spo2, "Ingresar spo2");
            }
            if (fcardiaca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fcardiaca, "Ingresar F.cardiaca");
            }
            if (eeg.Text == "")
            {
                ok = false;
                errorProvider1.SetError(eeg, "Ingresar eeg");
            }
            if (spco.Text == "")
            {
                ok = false;
                errorProvider1.SetError(spco, "Ingresar spco");
            }
            if (co.Text == "")
            {
                ok = false;
                errorProvider1.SetError(co, "Ingresar CO");
            }
            if (o2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(o2, "Ingresar 02");
            }
            if (apnea.Text == "")
            {
                ok = false;
                errorProvider1.SetError(apnea, "Ingresar Apnea");
            }
            if (temperatura.Text == "")
            {
                ok = false;
                errorProvider1.SetError(temperatura, "Ingresar Temperatura");
            }
            if (fcerebral.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fcerebral, "Ingresar F.cerebral");
            }
            if (frespiratoria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frespiratoria, "Ingresar F.respiratoria");
            }
            if (presioninvasiva.Text == "")
            {
                ok = false;
                errorProvider1.SetError(presioninvasiva, "Ingresar Presion Invasiva");
            }
            if (arritmia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(arritmia, "Ingresar arritmia");
            }
            if (presionnoinv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(presionnoinv, "Ingresar presion no inv");
            }
            if (ph.Text == "")
            {
                ok = false;
                errorProvider1.SetError(ph, "Ingresar ph");
            }
            if (masa.Text == "")
            {
                ok = false;
                errorProvider1.SetError(masa, "Ingresar masa");
            }
            if (pic.Text == "")
            {
                ok = false;
                errorProvider1.SetError(pic, "Ingresar pic");
            }
            if (bis.Text == "")
            {
                ok = false;
                errorProvider1.SetError(bis, "Ingresar bis");
            }
            if (vcv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(vcv, "Ingresar vcv");
            }
            if (pcv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(pcv, "Ingresar pcv");
            }
            if (simv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(simv, "Ingresar simv");
            }
            if (peep.Text == "")
            {
                ok = false;
                errorProvider1.SetError(peep, "Ingresar peep");
            }
            if (psv.Text == "")
            {
                ok = false;
                errorProvider1.SetError(psv, "Ingresar psv");
            }
            if (mac.Text == "")
            {
                ok = false;
                errorProvider1.SetError(mac, "Ingresar mac");
            }
            if (no2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(no2, "Ingresar no2");
            }
            if (fio2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fio2, "Ingresar fio2");
            }
            if (otro_2.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otro_2, "Ingresar otro");
            }
            //Parte 8
            if (manual_op.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_op, "Ingresar manual");
            }

            if (manual_inst.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_inst, "Ingresar manual inst.");
            }
            if (manual_servi.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_servi, "Ingresar manual serv.");
            }
            if (manual_part.Text == "")
            {
                ok = false;
                errorProvider1.SetError(manual_part, "Ingresar manual part.");
            }
            if (otra_lit.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otra_lit, "Ingresar otro literatura");
            }
            if (no_existe.Text == "")
            {
                ok = false;
                errorProvider1.SetError(otra_lit, "Ingresar ");
            }
            //Parte 9
            if (estatus.Text == "")
            {
                ok = false;
                errorProvider1.SetError(estatus, "Ingresar estatus");
            }

            // no_operativo.Text == ""
            // obs_estatus.Text = "";

            //Parte 10

            //No es necesario que llenen todos los campos

            //Parte 11

            if (garantia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(garantia, "Ingresar garantia");
            }
            if (contrato.Text == "")
            {
                ok = false;
                errorProvider1.SetError(contrato, "Ingresar contrato");
            }
            if (frecuencia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(frecuencia, "Ingresar frecuencia");
            }
            if (responsable.Text == "")
            {
                ok = false;
                errorProvider1.SetError(responsable, "Ingresar responsable");
            }

            //Parte 12

            if (nombre_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(nombre_resp, "Ingresar nombre responsable");
            }
            if (cargo_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cargo_resp, "Ingresar cargo responsable");
            }
            if (telefono_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(telefono_resp, "Ingresar telefono responsable");
            }
            if (email_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(email_resp, "Ingresar email responsable");
            }
            if (fecha_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(fecha_resp, "Ingresar fecha emision");
            }
            if (firma_resp.Text == "")
            {
                ok = false;
                errorProvider1.SetError(firma_resp, "Ingresar firma");
            }
            if (ok == false)
            {
                 MessageBox.Show("Error al ingreso de datos. Verifique que los datos sean los correctos", "Advertencia");
            }
            else {
                MessageBox.Show("Se ha ingresado correctamente los Datos");
            }
            return ok;

        }

        // Borrar el mensaje de error de la casilla
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(bien, "");
            errorProvider1.SetError(equipo, "");
            errorProvider1.SetError(marca, "");
            errorProvider1.SetError(modelo, "");
            errorProvider1.SetError(serie, "");
            errorProvider1.SetError(year, "");
            //Parte 2
            errorProvider1.SetError(vol, "");
            errorProvider1.SetError(fase_voltaje, "");
            errorProvider1.SetError(corriente, "");
            errorProvider1.SetError(potencia, "");
            errorProvider1.SetError(frecuencia, "");
            errorProvider1.SetError(bateria, "");
            errorProvider1.SetError(memory, "");
            errorProvider1.SetError(observaciones_1, "");
            errorProvider1.SetError(channels, "");
            //Parte 3
            errorProvider1.SetError(valor_adq, "");
            errorProvider1.SetError(n_factura, "");
            errorProvider1.SetError(f_adquisicion, "");
            errorProvider1.SetError(fecha_economicos, "");
            errorProvider1.SetError(vida_util, "");
            //Parte 4
            errorProvider1.SetError(unidad_op, "");
            errorProvider1.SetError(servicio, "");
            errorProvider1.SetError(sub_servicio, "");
            errorProvider1.SetError(nombre_custodio, "");
            errorProvider1.SetError(zona, "");
            errorProvider1.SetError(distrito, "");
            errorProvider1.SetError(provincia, "");
            errorProvider1.SetError(ciudad, "");
            //Parte 5
            errorProvider1.SetError(fabricante, "");
            errorProvider1.SetError(direccion_fab, "");
            errorProvider1.SetError(telefono_fab, "");
            errorProvider1.SetError(email_fab, "");
            errorProvider1.SetError(proveedor, "");
            errorProvider1.SetError(direccion_prov, "");
            errorProvider1.SetError(telefono_prov, "");
            errorProvider1.SetError(email_prov, "");
            errorProvider1.SetError(telefono_prov, "");
            errorProvider1.SetError(nombre_prov, "");
            errorProvider1.SetError(repre_pais, "");
            errorProvider1.SetError(direccion_rep, "");
            errorProvider1.SetError(telefono_rep, "");
            errorProvider1.SetError(email_rep, "");
            errorProvider1.SetError(nombre_rep, "");
            errorProvider1.SetError(email_rep, "");
            errorProvider1.SetError(prov_mant, "");
            errorProvider1.SetError(direccion_mant, "");
            errorProvider1.SetError(telefono_mant, "");
            errorProvider1.SetError(email_mant, "");
            errorProvider1.SetError(nombre_mant, "");
            errorProvider1.SetError(prov_calib, "");
            errorProvider1.SetError(direccion_calib, "");
            errorProvider1.SetError(telefono_calib, "");
            errorProvider1.SetError(email_calib, "");
            errorProvider1.SetError(nombre_calib, "");
            //Parte 6
            errorProvider1.SetError(electrico, "");
            errorProvider1.SetError(mecanico, "");
            errorProvider1.SetError(electronico, "");
            errorProvider1.SetError(hidraulico, "");
            errorProvider1.SetError(neumatico, "");
            errorProvider1.SetError(electromecanico, "");
            errorProvider1.SetError(vapor, "");
            errorProvider1.SetError(glp_1, "");
            errorProvider1.SetError(gases_medicinales, "");
            errorProvider1.SetError(aire_comp, "");
            errorProvider1.SetError(agua_fria, "");
            errorProvider1.SetError(agua_caliente, "");
            errorProvider1.SetError(agua_desc, "");
            errorProvider1.SetError(gases_medicinales, "");
            errorProvider1.SetError(otro_1, "");
            //Parte 7

            errorProvider1.SetError(ecg, "");
            errorProvider1.SetError(spo2, "");
            errorProvider1.SetError(fcardiaca, "");
            errorProvider1.SetError(eeg, "");
            errorProvider1.SetError(spco, "");
            errorProvider1.SetError(co, "");
            errorProvider1.SetError(o2, "");
            errorProvider1.SetError(apnea, "");
            errorProvider1.SetError(temperatura, "");
            errorProvider1.SetError(fcerebral, "");
            errorProvider1.SetError(frespiratoria, "");
            errorProvider1.SetError(presioninvasiva, "");
            errorProvider1.SetError(arritmia, "");
            errorProvider1.SetError(presionnoinv, "");
            errorProvider1.SetError(ph, "");
            errorProvider1.SetError(masa, "");
            errorProvider1.SetError(pic, "");
            errorProvider1.SetError(bis, "");
            errorProvider1.SetError(vcv, "");
            errorProvider1.SetError(pcv, "");
            errorProvider1.SetError(simv, "");
            errorProvider1.SetError(peep, "");
            errorProvider1.SetError(psv, "");
            errorProvider1.SetError(mac, "");
            errorProvider1.SetError(no2, "");
            errorProvider1.SetError(fio2, "");
            errorProvider1.SetError(otro_2, "");
            //Parte 8
            errorProvider1.SetError(manual_op, "");
            errorProvider1.SetError(manual_inst, "");
            errorProvider1.SetError(manual_servi, "");
            errorProvider1.SetError(manual_part, "");
            errorProvider1.SetError(otra_lit, "");
            errorProvider1.SetError(no_existe, "");
            //Parte 9
            errorProvider1.SetError(estatus, "");
            //Parte 10

            //Parte 11
            errorProvider1.SetError(garantia, "");
            errorProvider1.SetError(contrato, "");
            errorProvider1.SetError(frecuencia, "");
            errorProvider1.SetError(responsable, "");
            //Parte 12
            errorProvider1.SetError(nombre_resp, "");
            errorProvider1.SetError(cargo_resp, "");
            errorProvider1.SetError(telefono_resp, "");
            errorProvider1.SetError(email_resp, "");
            errorProvider1.SetError(fecha_resp, "");
            errorProvider1.SetError(firma_resp, "");
        }


        private void observaciones_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void subirimg_Click(object sender, EventArgs e)
        {

        }

        private void year_Validating(object sender, CancelEventArgs e)
        {

        }

        // Mensajes de advertencia dependiendo al tipo de dato 

        private void Advertencia(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void vol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void corriente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void frecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void potencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void bateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void channels_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void n_factura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_fab_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_prov_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_rep_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_mant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_calib_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void telefono_resp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Advertencia(sender, e);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tipo_registro_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void tipo_registro_SelectedIndexChanged(object sender, EventArgs e)

        {
            //llamando a funcion 

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = "select valor_registro('" + serie.Text + "')";
            cmd.Connection = cn;
            //MessageBox.Show(serie.Text.ToString());
            NpgsqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            //MessageBox.Show(dr[0].ToString());
            int x = (int)dr[0];

            dr.Close();

            if (x == 0 && tipo_registro.Text == "Mantenimiento")
            {
                MessageBox.Show("el dispositovo " + serie.Text + " Aun no esta registrado");
                tipo_registro.Text = "Registro dispositovo";

            }
            else if (x > 0 && tipo_registro.Text == "Registro dispositovo")
            {
                MessageBox.Show("el dispositovo " + serie.Text + " ya esta registrado");
                tipo_registro.Text = "Mantenimiento";
                //x = x + 1;
            }
            else if (x > 0)
            {
                //x = x + 1;
                LLenado();
            }
            tipo_registro_valor.Text = x.ToString();
            Desbloquear_bloquear(true);



        }

        private void Desbloquear_bloquear(bool x){
            bool valor;
            bool valor_f;
            if (x) { valor = true; valor_f = false; }
            else { valor = false; valor_f = true; }
            //descripcion del equipo
            bien.Enabled = valor;
            equipo.ReadOnly = valor_f;
            marca.ReadOnly = valor_f;
            modelo.ReadOnly = valor_f;
            //textBox8.ReadOnly = valor_f;
            year.ReadOnly = valor_f;
            serie.ReadOnly = valor;
            tipo_registro.Enabled = valor_f;
            //equip_tdata datos técnicos
            vol.ReadOnly = valor_f;
            fase_voltaje.Enabled = valor;
            corriente.ReadOnly = valor_f;
            potencia.ReadOnly = valor_f;
            frecuencia.ReadOnly = valor_f;
            bateria.ReadOnly = valor_f;
            channels.ReadOnly = valor_f;
            memory.ReadOnly = valor_f;
            printer.ReadOnly = valor_f;
            observaciones_1.ReadOnly = valor_f;
            //datos_economicos 
            valor_adq.ReadOnly = valor_f;
            n_factura.ReadOnly = valor_f;
            f_adquisicion.Enabled = valor;
            fecha_economicos.Enabled = valor;
            vida_util.ReadOnly = valor_f;

            //datos de ubicacion del equipo
            unidad_op.Enabled = valor;
            servicio.Enabled = valor;
            sub_servicio.ReadOnly = valor_f;
            nombre_custodio.ReadOnly = valor_f;
            zona.Enabled = valor;
            distrito.Enabled = valor;
            provincia.Enabled = valor;
            ciudad.Enabled = valor;

            //datos provedor
            fabricante.ReadOnly = valor_f;
            direccion_fab.ReadOnly = valor_f;
            telefono_fab.ReadOnly = valor_f;
            email_fab.ReadOnly = valor_f;
            proveedor.ReadOnly = valor_f;
            direccion_prov.ReadOnly = valor_f;
            telefono_prov.ReadOnly = valor_f;
            email_prov.ReadOnly = valor_f;
            nombre_prov.ReadOnly = valor_f;
            repre_pais.ReadOnly = valor_f;
            direccion_rep.ReadOnly = valor_f;
            telefono_rep.ReadOnly = valor_f;
            email_rep.ReadOnly = valor_f;
            nombre_rep.ReadOnly = valor_f;
            prov_mant.ReadOnly = valor_f;
            direccion_mant.ReadOnly = valor_f;
            telefono_mant.ReadOnly = valor_f;
            email_mant.ReadOnly = valor_f;
            nombre_mant.ReadOnly = valor_f;
            prov_calib.ReadOnly = valor_f;
            direccion_calib.ReadOnly = valor_f;
            telefono_calib.ReadOnly = valor_f;
            email_calib.ReadOnly = valor_f;
            nombre_calib.ReadOnly = valor_f;

            //requerimientos de equipo
            electrico.Enabled = valor;
            m_electrico.ReadOnly = valor_f;
            mecanico.Enabled = valor;
            m_mecanico.ReadOnly = valor_f;
            electronico.Enabled = valor;
            m_electronico.ReadOnly = valor_f;
            hidraulico.Enabled = valor;
            m_hidraulico.ReadOnly = valor_f;
            neumatico.Enabled = valor;
            m_neumatico.ReadOnly = valor_f;
            electromecanico.Enabled = valor;
            m_electromecanico.ReadOnly = valor_f;
            vapor.Enabled = valor;
            m_vapor.ReadOnly = valor_f;
            glp_1.Enabled = valor;
            m_glp.ReadOnly = valor_f;
            gases_medicinales.Enabled = valor;
            m_gases_medicinales.ReadOnly = valor_f;
            aire_comp.Enabled = valor;
            m_aire_comp.ReadOnly = valor_f;
            agua_fria.Enabled = valor;
            m_agua_fria.ReadOnly = valor_f;
            agua_caliente.Enabled = valor;
            m_agua_caliente.ReadOnly = valor_f;
            agua_desc.Enabled = valor;
            m_agua_descalcificada.ReadOnly = valor_f;
            otro_1.Enabled = valor;
            m_otro.ReadOnly = valor_f;

            //parametros del equipo
            ecg.Enabled = valor;
            spo2.Enabled = valor;
            fcardiaca.Enabled = valor;
            presionnoinv.Enabled = valor;
            eeg.Enabled = valor;
            spco.Enabled = valor;
            co.Enabled = valor;
            o2.Enabled = valor;
            apnea.Enabled = valor;
            temperatura.Enabled = valor;
            fcerebral.Enabled = valor;
            frespiratoria.Enabled = valor;
            presioninvasiva.Enabled = valor;
            arritmia.Enabled = valor;
            ph.Enabled = valor;
            masa.Enabled = valor;
            pic.Enabled = valor;
            bis.Enabled = valor;
            vcv.Enabled = valor;
            pcv.Enabled = valor;
            simv.Enabled = valor;
            peep.Enabled = valor; 
            psv.Enabled = valor;
            mac.Enabled = valor;
            no2.Enabled  = valor;
            fio2.Enabled = valor;
            otro_2.Enabled = valor;

            //estado del bien
            estatus.Enabled = valor;
            no_operativo.Enabled = valor;
            obs_estatus.ReadOnly = valor_f;

            //accesorios del equipo
            primero.ReadOnly = valor_f;
            segundo.ReadOnly = valor_f;
            tercero.ReadOnly = valor_f;
            cuarto.ReadOnly = valor_f;
            quinto.ReadOnly = valor_f;
            sexto.ReadOnly = valor_f;
            estado_pr.Enabled = valor;
            estado_sec.Enabled = valor;
            estado_ter.Enabled = valor;
            estado_cu.Enabled = valor;
            estado_qu.Enabled = valor;
            estado_sexto.Enabled = valor;
            obs_accesorios.ReadOnly = valor_f;

            //informacion tecnica
            manual_op.Enabled = valor;
            manual_inst.Enabled = valor;
            manual_servi.Enabled = valor;
            manual_part.Enabled = valor;
            otra_lit.Enabled = valor;
            no_existe.Enabled = valor;

            //otros datos
            garantia.Enabled = valor;
            contrato.Enabled = valor;
            frec.ReadOnly = valor_f;
            responsable.ReadOnly = valor_f;
            obs_otros.ReadOnly = valor_f;

            //registro elab y actualizacion
            nombre_resp.ReadOnly = valor_f;
            cargo_resp.ReadOnly = valor_f;
            telefono_resp.ReadOnly = valor_f;
            email_resp.ReadOnly = valor_f;
            fecha_resp.Enabled = valor;
            firma_resp.ReadOnly = valor_f;

        }

        private void label120_Click(object sender, EventArgs e)
        {

        }
        void LLenado() 
        {
            NpgsqlCommand cmd1 = new NpgsqlCommand();
            string SQL_q = "select * from equip_description,equip_tdata,datos_economicos,ubicacion_equipo,datos_proveedor,equip_requirements,";
            SQL_q = SQL_q + "equip_parameters,estado_bien,accesorio_equipo,info_tecnica,otros_datos,registro_elab where";
            SQL_q = SQL_q + " tipo_registro = '0' and serie = '" + serie.Text + "'and n_tipo_registro = '0' and n_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n3_tipo_registro = '0' and n3_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n4_tipo_registro = '0' and n4_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n5_tipo_registro = '0' and n5_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n1_tipo_registro = '0' and n1_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n2_tipo_registro = '0' and n2_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n7_tipo_registro = '0' and n7_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n8_tipo_registro = '0' and n8_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n6_tipo_registro = '0' and n6_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n9_tipo_registro = '0' and n9_serie = '" + serie.Text + "' and ";
            SQL_q = SQL_q + "n10_tipo_registro = '0' and n10_serie = '" + serie.Text + "';";
            cmd1.CommandText = SQL_q;
            
            cmd1.Connection = cn;
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            //descripcion del bien
            //MessageBox.Show(dr1[7].ToString() + " " + dr1[8].ToString() + " " + dr1[9].ToString());
            bien.Text = dr1[0].ToString();
            equipo.Text = dr1[1].ToString();
            marca.Text = dr1[2].ToString();
            modelo.Text = dr1[3].ToString();
            //textBox8.Text = dr1[].ToString();
            year.Text = dr1[6].ToString();

            //equip_tdata datos técnicos
            vol.Text = dr1[9].ToString(); 
            fase_voltaje.Text = dr1[10].ToString(); 
            corriente.Text = dr1[11].ToString(); 
            potencia.Text = dr1[12].ToString();
            frecuencia.Text = dr1[13].ToString(); 
            bateria.Text = dr1[14].ToString();
            channels.Text = dr1[15].ToString(); 
            memory.Text = dr1[16].ToString(); 
            printer.Text = dr1[17].ToString();
            observaciones_1.Text = dr1[18].ToString();

            //datos_economicos 
            valor_adq.Text = dr1[21].ToString();
            n_factura.Text = dr1[22].ToString();
            f_adquisicion.Text = dr1[23].ToString();
            fecha_economicos.Text = dr1[24].ToString();
            vida_util.Text = dr1[25].ToString();

            //datos de ubicacion del equipo
            unidad_op.Text = dr1[28].ToString();
            servicio.Text = dr1[29].ToString();
            sub_servicio.Text = dr1[30].ToString();
            nombre_custodio.Text = dr1[31].ToString();
            zona.Text = dr1[32].ToString();
            distrito.Text = dr1[33].ToString();
            provincia.Text = dr1[34].ToString();
            ciudad.Text = dr1[35].ToString();

            //datos provedor
            fabricante.Text = dr1[38].ToString();
            direccion_fab.Text = dr1[39].ToString(); 
            telefono_fab.Text = dr1[40].ToString();
            email_fab.Text = dr1[41].ToString();
            proveedor.Text = dr1[42].ToString();
            direccion_prov.Text = dr1[43].ToString();
            telefono_prov.Text = dr1[44].ToString();
            email_prov.Text = dr1[45].ToString();
            nombre_prov.Text = dr1[46].ToString();
            repre_pais.Text = dr1[47].ToString();
            direccion_rep.Text = dr1[48].ToString();
            telefono_rep.Text = dr1[49].ToString();
            email_rep.Text = dr1[50].ToString();
            nombre_rep.Text = dr1[51].ToString();
            prov_mant.Text = dr1[52].ToString();
            direccion_mant.Text = dr1[53].ToString();
            telefono_mant.Text = dr1[54].ToString();
            email_mant.Text = dr1[55].ToString();
            nombre_mant.Text = dr1[56].ToString();
            prov_calib.Text = dr1[57].ToString();
            direccion_calib.Text = dr1[58].ToString();
            telefono_calib.Text = dr1[59].ToString();
            email_calib.Text = dr1[60].ToString();
            nombre_calib.Text = dr1[61].ToString();

            //tercera tabla requerimientos de mantenimiento
            electrico.Text = dr1[64].ToString();
            m_electrico.Text = dr1[65].ToString();
            mecanico.Text = dr1[66].ToString();
            m_mecanico.Text = dr1[67].ToString();
            electronico.Text = dr1[68].ToString();
            m_electronico.Text = dr1[69].ToString();
            hidraulico.Text = dr1[70].ToString();
            m_hidraulico.Text = dr1[71].ToString(); 
            neumatico.Text = dr1[72].ToString();
            m_neumatico.Text = dr1[73].ToString();
            electromecanico.Text = dr1[74].ToString();
            m_electromecanico.Text = dr1[75].ToString();
            vapor.Text = dr1[76].ToString();
            m_vapor.Text = dr1[77].ToString();
            glp_1.Text = dr1[78].ToString();
            m_glp.Text = dr1[79].ToString();
            gases_medicinales.Text = dr1[80].ToString();
            m_gases_medicinales.Text = dr1[81].ToString();
            aire_comp.Text = dr1[82].ToString();
            m_aire_comp.Text = dr1[83].ToString();
            agua_fria.Text = dr1[84].ToString();
            m_agua_fria.Text = dr1[85].ToString();
            agua_caliente.Text = dr1[86].ToString();
            m_agua_caliente.Text = dr1[87].ToString();
            agua_desc.Text = dr1[88].ToString();
            m_agua_descalcificada.Text = dr1[89].ToString();
            otro_1.Text = dr1[90].ToString();
            m_otro.Text = dr1[91].ToString();

            //parametros del equipo
            ecg.Text = dr1[94].ToString();
            spo2.Text = dr1[95].ToString();
            fcardiaca.Text = dr1[96].ToString();
            presionnoinv.Text = dr1[97].ToString();
            eeg.Text = dr1[98].ToString();
            spco.Text = dr1[99].ToString();
            co.Text = dr1[100].ToString();
            o2.Text = dr1[101].ToString();
            apnea.Text = dr1[102].ToString();
            temperatura.Text = dr1[103].ToString();
            fcerebral.Text = dr1[104].ToString();
            frespiratoria.Text = dr1[105].ToString();
            presioninvasiva.Text = dr1[106].ToString();
            arritmia.Text = dr1[107].ToString();
            ph.Text = dr1[108].ToString();
            masa.Text = dr1[109].ToString();
            pic.Text = dr1[110].ToString();
            bis.Text = dr1[111].ToString();
            vcv.Text = dr1[112].ToString();
            pcv.Text = dr1[113].ToString();
            simv.Text = dr1[114].ToString();
            peep.Text = dr1[115].ToString();
            psv.Text = dr1[116].ToString();
            mac.Text = dr1[117].ToString();
            no2.Text = dr1[118].ToString();
            fio2.Text = dr1[119].ToString();
            otro_2.Text = dr1[120].ToString();

            //estado del bien 
            estatus.Text = dr1[123].ToString();
            no_operativo.Text = dr1[124].ToString();
            obs_estatus.Text = dr1[125].ToString();
            //accersorio del equipo 
            primero.Text = dr1[128].ToString();
            segundo.Text = dr1[129].ToString();
            tercero.Text = dr1[130].ToString();
            cuarto.Text = dr1[131].ToString();
            quinto.Text = dr1[132].ToString();
            sexto.Text = dr1[133].ToString();
            estado_pr.Text = dr1[134].ToString();
            estado_sec.Text = dr1[135].ToString();
            estado_ter.Text = dr1[136].ToString();
            estado_cu.Text = dr1[137].ToString();
            estado_qu.Text = dr1[138].ToString();
            estado_sexto.Text = dr1[139].ToString();
            obs_accesorios.Text = dr1[140].ToString();

            //informacion tecnica
            manual_op.Text = dr1[143].ToString();
            manual_inst.Text = dr1[144].ToString();
            manual_servi.Text = dr1[145].ToString();
            manual_part.Text = dr1[146].ToString();
            otra_lit.Text = dr1[147].ToString();
            no_existe.Text = dr1[148].ToString();

            //otros datos
            garantia.Text = dr1[151].ToString();
            contrato.Text = dr1[152].ToString();
            frec.Text = dr1[153].ToString();
            responsable.Text = dr1[154].ToString();
            obs_otros.Text = dr1[155].ToString();

            //registro elab y actualizaciones
            nombre_resp.Text = dr1[158].ToString();
            cargo_resp.Text = dr1[159].ToString();
            telefono_resp.Text = dr1[160].ToString();
            email_resp.Text = dr1[161].ToString();
            fecha_resp.Text = dr1[162].ToString();
            firma_resp.Text = dr1[163].ToString();


            dr1.Close();



        }

        void Limpiar_campos() {
            //descripcion del bien
            bien.Text = ""; equipo.Text = ""; marca.Text = ""; modelo.Text = ""; 
            tipo_registro.Text = ""; year.Text = ""; serie.Text = "";
            //datos técnicos
            vol.Text = ""; fase_voltaje.Text = ""; corriente.Text = ""; potencia.Text = "";
            frecuencia.Text = ""; bateria.Text = ""; memory.Text = ""; printer.Text = ""; 
            observaciones_1.Text = ""; channels.Text = "";
            //datos economicos
            valor_adq.Text = ""; n_factura.Text = ""; f_adquisicion.Text = "";
            fecha_economicos.Text = ""; vida_util.Text = "";
            //datos de ubicacion del equipo
            unidad_op.Text = ""; servicio.Text = ""; sub_servicio.Text = ""; nombre_custodio.Text = "";
            zona.Text = ""; distrito.Text = ""; provincia.Text = ""; ciudad.Text = "";
            //datos provedor
            fabricante.Text = ""; direccion_fab.Text = ""; telefono_fab.Text = ""; email_fab.Text = ""; 
            proveedor.Text = ""; direccion_prov.Text = ""; telefono_prov.Text = ""; email_prov.Text = "";
            nombre_prov.Text = ""; repre_pais.Text = ""; direccion_rep.Text = ""; telefono_rep.Text = "";
            email_rep.Text = ""; nombre_rep.Text = ""; prov_mant.Text = ""; direccion_mant.Text = "";
            telefono_mant.Text = ""; email_mant.Text = ""; nombre_mant.Text = ""; prov_calib.Text = "";
            direccion_calib.Text = "";  telefono_calib.Text = ""; email_calib.Text = ""; nombre_calib.Text = "";
            //tercera tabla requerimientos de mantenimiento
            electrico.Text = ""; m_electrico.Text = ""; mecanico.Text = ""; m_mecanico.Text = "";
            electronico.Text = ""; m_electronico.Text = ""; hidraulico.Text = ""; m_hidraulico.Text = "";
            neumatico.Text = ""; m_neumatico.Text = ""; electromecanico.Text = ""; m_electromecanico.Text = "";
            vapor.Text = ""; m_vapor.Text = ""; glp_1.Text = ""; m_glp.Text = "";
            gases_medicinales.Text = ""; m_gases_medicinales.Text = ""; aire_comp.Text = "";
            m_aire_comp.Text = ""; agua_fria.Text = ""; m_agua_fria.Text = ""; agua_caliente.Text = "";
            m_agua_caliente.Text = ""; agua_desc.Text = ""; m_agua_descalcificada.Text = "";
            otro_1.Text = ""; m_otro.Text = "";

            //curarta tabla PARAMETROS MEDIDOS
            ecg.Text = ""; spo2.Text = ""; fcardiaca.Text = ""; presionnoinv.Text = "";
            eeg.Text = ""; spco.Text = ""; co.Text = ""; o2.Text = "";
            apnea.Text = ""; temperatura.Text = ""; fcerebral.Text = "";
            frespiratoria.Text = ""; presioninvasiva.Text = ""; arritmia.Text = "";
            ph.Text = ""; masa.Text = ""; pic.Text = ""; bis.Text = "";
            vcv.Text = ""; pcv.Text = ""; simv.Text = ""; peep.Text = "";
            psv.Text = ""; mac.Text = ""; no2.Text = ""; fio2.Text = "";
            otro_2.Text = "";

            // Informacion tecnica
            manual_op.Text = ""; manual_inst.Text = ""; manual_servi.Text = "";
            manual_part.Text = ""; otra_lit.Text = ""; no_existe.Text = "";
            //Estado del bien

            estatus.Text = ""; no_operativo.Text = ""; obs_estatus.Text = "";
            //Accesorios del equipo
            primero.Text = ""; segundo.Text = ""; tercero.Text = ""; cuarto.Text = "";
            quinto.Text = ""; sexto.Text = ""; estado_pr.Text = ""; estado_sec.Text = "";
            estado_ter.Text = ""; estado_cu.Text = ""; estado_qu.Text = ""; estado_sexto.Text = "";
            obs_accesorios.Text = "";
            //Otros datos Error
            garantia.Text = ""; contrato.Text = ""; frecuencia.Text = ""; responsable.Text = "";
            obs_otros.Text = ""; frec.Text = "";
            //Elaboracion y actualizacion
            nombre_resp.Text = ""; cargo_resp.Text = ""; telefono_resp.Text = "";
            email_resp.Text = ""; fecha_resp.Text = ""; firma_resp.Text = "";




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nuevo_registro_Click(object sender, EventArgs e)
        {
            serie.ReadOnly = false;
            tipo_registro.Enabled = true;
            Limpiar_campos();
            Desbloquear_bloquear(false);


        }

        private void psv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void correo_Click(object sender, EventArgs e)
        {
            string Error = " ";
            StringBuilder MessageBuilder = new StringBuilder();
            MessageBuilder.Append("este es un mensaje de prueba");
            EnviarCorreo(MessageBuilder,DateTime.Now, "jhonndiegoo@gmail.com".Trim(), "jhonndiegoo@gmail.com".Trim(),"prueba".Trim(),out Error);
        }

        public static void EnviarCorreo( StringBuilder Mensaje, DateTime FechaEnvio, string De, string Para, string Asunto, out string Error) {
            Error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(string.Format("Este correo ha sido enviado el dia {0:dd/MM/yyyy} a las {0:HH:mm:ss} Hrs: \n\n", FechaEnvio));
                Mensaje.Append(Environment.NewLine);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(De);
                mail.To.Add(Para);
                mail.Subject = Asunto;
                mail.Body = Mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                Error = " Exito envio ";
                MessageBox.Show(Error);

            }
            catch (Exception ex)
            {
                Error = "Eroor " + ex.Message;
                MessageBox.Show(Error);
                return;
            }

        }
    }   

}

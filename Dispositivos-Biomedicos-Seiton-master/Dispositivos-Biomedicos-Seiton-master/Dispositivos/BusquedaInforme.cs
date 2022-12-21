using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dispositivos
{
    public partial class BusquedaInforme : Form
    {
        public BusquedaInforme()
        {
            InitializeComponent();
        }
        string True_false(string booleanS) => booleanS == "True" ? "SI" : "NO";
        private void BusquedaInforme_Load(object sender, EventArgs e)
        {
            //equipo description
            tipo_registro.Text = DatosInforme.equip_descriptionD["tipo_registro"];
            tipo_registro.Visible = true;
            tipo_bien.Text = DatosInforme.equip_descriptionD["tipo_bien"] ;
            tipo_bien.Visible = true;
            nombre_equipo.Text =  DatosInforme.equip_descriptionD["Nombre_equipo"] ;
            nombre_equipo.Visible = true;
            marca.Text =  DatosInforme.equip_descriptionD["Marca"]  ;
            marca.Visible = true;
            modelo.Text =  DatosInforme.equip_descriptionD["Modelo"]  ;
            modelo.Visible = true;
            serie.Text = DatosInforme.equip_descriptionD["Serie"]  ;
            serie.Visible = true;
            fab_year.Text = DatosInforme.equip_descriptionD["fab_year"] ;
            fab_year.Visible = true;

            //equip_tdata
            voltaje.Text = DatosInforme.equipo_tdata["n_serie"];
            voltaje.Visible = true;
            n_fase.Text = DatosInforme.equipo_tdata["fase"];
            n_fase.Visible = true;
            corriente.Text = DatosInforme.equipo_tdata["corriente"];
            corriente.Visible = true;
            potencia.Text = DatosInforme.equipo_tdata["potencia"];
            potencia.Visible = true;
            frecuencia.Text = DatosInforme.equipo_tdata["frecuencia"];
            frecuencia.Visible = true;
            bateria.Text = DatosInforme.equipo_tdata["bateria"];
            bateria.Visible = true;
            n_canales.Text = DatosInforme.equipo_tdata["channels"];
            n_canales.Visible = true;
            memoria.Text = DatosInforme.equipo_tdata["memory"];
            memoria.Visible = true;
            t_impresora.Text = DatosInforme.equipo_tdata["printer"];
            t_impresora.Visible = true;
            observaciones.Text = DatosInforme.equipo_tdata["observaciones"];
            observaciones.Visible = true;

            //equip_requeriments
            electricobool.Text = True_false(DatosInforme.equipo_requirements["electrico"]);
            electricobool.Visible = true;
            electricoM.Text = DatosInforme.equipo_requirements["med_electrico"];
            electricoM.Visible = true;
            mecanicobool.Text = True_false(DatosInforme.equipo_requirements["mecanico"]);
            mecanicobool.Visible = true;
            mecanicoM.Text = DatosInforme.equipo_requirements["med_mecanico"];
            mecanicoM.Visible = true;
            electronicobool.Text = True_false(DatosInforme.equipo_requirements["electronico"]);
            electronicobool.Visible = true;
            electronicoM.Text = DatosInforme.equipo_requirements["med_electronico"];
            electronicoM.Visible = true;
            hidraulicobool.Text = True_false(DatosInforme.equipo_requirements["hidraulico"]);
            hidraulicobool.Visible = true;
            hidraulicoM.Text = DatosInforme.equipo_requirements["med_hidraulico"];
            hidraulicoM.Visible = true;
            neumaticobool.Text = True_false(DatosInforme.equipo_requirements["neumatico"]);
            neumaticobool.Visible = true;
            neumaticoM.Text = DatosInforme.equipo_requirements["med_neumatico"];
            neumaticoM.Visible = true;
            electromecanicobool.Text = True_false(DatosInforme.equipo_requirements["electromicanico"]);
            electromecanicobool.Visible = true;
            electromecanicoM.Text = DatosInforme.equipo_requirements["med_electromicanico"];
            electromecanicoM.Visible = true;
            vaporbool.Text = True_false(DatosInforme.equipo_requirements["vapor"]);
            vaporbool.Visible = true;
            VaporM.Text = DatosInforme.equipo_requirements["med_vapor"];
            VaporM.Visible = true;
            glpbool.Text = True_false(DatosInforme.equipo_requirements["glp"]);
            glpbool.Visible = true;
            glpM.Text = DatosInforme.equipo_requirements["med_glp"];
            glpM.Visible = true;
            gases_medicinalesbool.Text = True_false(DatosInforme.equipo_requirements["medicinal"]);
            gases_medicinalesbool.Visible = true;
            gases_medicinalesM.Text = DatosInforme.equipo_requirements["med_medicinal"];
            gases_medicinalesM.Visible = true;
            aire_comprimidobool.Text = True_false(DatosInforme.equipo_requirements["a_comprimido"]);
            aire_comprimidobool.Visible = true;
            aire_comprimidoM.Text = DatosInforme.equipo_requirements["med_a_comprimido"];
            aire_comprimidoM.Visible = true;
            agua_friaboool.Text = True_false(DatosInforme.equipo_requirements["a_fria"]);
            agua_friaboool.Visible = true;
            agua_friaM.Text = DatosInforme.equipo_requirements["med_a_fria"];
            agua_friaM.Visible = true;
            agua_calientebool.Text = True_false(DatosInforme.equipo_requirements["a_caliente"]);
            agua_calientebool.Visible = true;
            agua_calienteM.Text = DatosInforme.equipo_requirements["med_a_caliente"];
            agua_calienteM.Visible = true;
            agua_descalcificadabool.Text = True_false(DatosInforme.equipo_requirements["a_descal"]);
            agua_descalcificadabool.Visible = true;
            agua_descalcificadaM.Text = DatosInforme.equipo_requirements["med_a_descal"];
            agua_descalcificadaM.Visible = true;
            otrobool.Text = True_false(DatosInforme.equipo_requirements["otro"]);
            otrobool.Visible = true;
            OtroM.Text = DatosInforme.equipo_requirements["med_otro"];
            OtroM.Visible = true;

            //equip_parameters
            ecgbool.Text = True_false(DatosInforme.equipo_parameters["ecg"]);
            ecgbool.Visible = true;
            spo2bool.Text = True_false(DatosInforme.equipo_parameters["spo2"]);
            spo2bool.Visible = true;
            f_cadiacabool.Text = True_false(DatosInforme.equipo_parameters["f_cardiaca"]);
            f_cadiacabool.Visible = true;
            eegbool.Text = True_false(DatosInforme.equipo_parameters["eeg"]);
            eegbool.Visible = true;
            spcobool.Text = True_false(DatosInforme.equipo_parameters["spco"]);
            spcobool.Visible = true;
            cobool.Text = True_false(DatosInforme.equipo_parameters["co"]);
            cobool.Visible = true;
            o2bool.Text = True_false(DatosInforme.equipo_parameters["o2"]);
            o2bool.Visible = true;
            apneabool.Text = True_false(DatosInforme.equipo_parameters["apnea"]);
            apneabool.Visible = true;
            temperaturabool.Text = True_false(DatosInforme.equipo_parameters["temperatura"]);
            temperaturabool.Visible = true;
            f_cerebralbool.Text = True_false(DatosInforme.equipo_parameters["f_cerebral"]);
            f_cerebralbool.Visible = true;
            f_respitaroriabool.Text = True_false(DatosInforme.equipo_parameters["f_respiratoria"]);
            f_respitaroriabool.Visible = true;
            presion_invasivabool.Text = True_false(DatosInforme.equipo_parameters["p_invasiva"]);
            presion_invasivabool.Visible = true;
            aritmiabool.Text = True_false(DatosInforme.equipo_parameters["arritmia"]);
            aritmiabool.Visible = true;
            presion_n_invasivabool.Text = True_false(DatosInforme.equipo_parameters["p_ninvasia"]);
            presion_n_invasivabool.Visible = true;
            phbool.Text = True_false(DatosInforme.equipo_parameters["ph"]);
            phbool.Visible = true;
            masabool.Text = True_false(DatosInforme.equipo_parameters["masa"]);
            masabool.Visible = true;
            picbool.Text = True_false(DatosInforme.equipo_parameters["pic"]);
            picbool.Visible = true;
            bisbool.Text = True_false(DatosInforme.equipo_parameters["bis"]);
            bisbool.Visible = true;
            vcvbool.Text = True_false(DatosInforme.equipo_parameters["vcv"]);
            vcvbool.Visible = true;
            pcvbool.Text = True_false(DatosInforme.equipo_parameters["pcv"]);
            pcvbool.Visible = true;
            simvbool.Text = True_false(DatosInforme.equipo_parameters["simv"]);
            simvbool.Visible = true;
            peepbool.Text = True_false(DatosInforme.equipo_parameters["peep"]);
            peepbool.Visible = true;
            psvbool.Text = True_false(DatosInforme.equipo_parameters["psv"]);
            psvbool.Visible = true;
            macbool.Text = True_false(DatosInforme.equipo_parameters["mac"]);
            macbool.Visible = true;
            no2bool.Text = True_false(DatosInforme.equipo_parameters["no2"]);
            no2bool.Visible = true;
            fio2bool.Text = True_false(DatosInforme.equipo_parameters["fio2"]);
            fio2bool.Visible = true;
            otro2bool.Text = True_false(DatosInforme.equipo_parameters["otro"]);
            otro2bool.Visible = true;

            //datos economicos
            valor_adqbool.Text = DatosInforme.datos_economicos["valor_adq"];
            valor_adqbool.Visible = true;
            n_facturabool.Text = DatosInforme.datos_economicos["n_factura"];
            n_facturabool.Visible = true;
            f_adquisicionbool.Text = DatosInforme.datos_economicos["f_adquisicion"];
            f_adquisicionbool.Visible = true;
            fecha2bool.Text = DatosInforme.datos_economicos["fecha"];
            fecha2bool.Visible = true;
            vida_utilbool.Text = DatosInforme.datos_economicos["vida_util"];
            vida_utilbool.Visible = true;

            //ubicacion equipo
            unidad_opbool.Text = DatosInforme.ubicacion_equipo["unidad_op"];
            unidad_opbool.Visible = true;
            serviciobool.Text = DatosInforme.ubicacion_equipo["servicio"];
            serviciobool.Visible = true;
            sub_serviciobool.Text = DatosInforme.ubicacion_equipo["sub_servicio"];
            sub_serviciobool.Visible = true;
            nombre_custodiobool.Text = DatosInforme.ubicacion_equipo["nombre_custodio"];
            nombre_custodiobool.Visible = true;
            zonabool.Text = DatosInforme.ubicacion_equipo["zona"];
            zonabool.Visible = true;
            distritobool.Text = DatosInforme.ubicacion_equipo["distrito"];
            distritobool.Visible = true;
            provinciabool.Text = DatosInforme.ubicacion_equipo["provincia"];
            provinciabool.Visible = true;
            ciudadbool.Text = DatosInforme.ubicacion_equipo["ciudad"];
            ciudadbool.Visible = true;

            //datos provedor
            
            fabricante.Text = DatosInforme.datos_proveedor["fabricante"];
            fabricante.Visible = true;
            direccion_fab.Text = DatosInforme.datos_proveedor["direccion_fab"];
            direccion_fab.Visible = true;
            telefono_fab.Text = DatosInforme.datos_proveedor["telefono_fab"];
            telefono_fab.Visible = true;
            email_fab.Text = DatosInforme.datos_proveedor["email_fab"];
            email_fab.Visible = true;

            provedor.Text = DatosInforme.datos_proveedor["provedor"];
            provedor.Visible = true;
            direccion_prov.Text = DatosInforme.datos_proveedor["direccion_prov"];
            direccion_prov.Visible = true;
            telefono_prov.Text = DatosInforme.datos_proveedor["telefono_prov"];
            telefono_prov.Visible = true;
            email_prov.Text = DatosInforme.datos_proveedor["email_prov"];
            email_prov.Visible = true;
            nombre_prov.Text = DatosInforme.datos_proveedor["nombre_prov_cont"];
            nombre_prov.Visible = true;

            representante_pais.Text = DatosInforme.datos_proveedor["representante_pais"];
            representante_pais.Visible = true;
            direccion_rep.Text = DatosInforme.datos_proveedor["direccion_rep"];
            direccion_rep.Visible = true;
            telefono_rep.Text = DatosInforme.datos_proveedor["telefono_rep"];
            telefono_rep.Visible = true;
            email_rep.Text = DatosInforme.datos_proveedor["email_rep"];
            email_rep.Visible = true;
            nombre_rep.Text = DatosInforme.datos_proveedor["nombre_rep"];
            nombre_rep.Visible = true;

            prov_manten.Text = DatosInforme.datos_proveedor["prov_manten"];
            prov_manten.Visible = true;
            direccion_mant.Text = DatosInforme.datos_proveedor["direccion_mant"];
            direccion_mant.Visible = true;
            telefono_mant.Text = DatosInforme.datos_proveedor["telefono_mant"];
            telefono_mant.Visible = true;
            email_mant.Text = DatosInforme.datos_proveedor["email_mant"];
            email_mant.Visible = true;
            nombre_mant.Text = DatosInforme.datos_proveedor["nombre_mant"];
            nombre_mant.Visible = true;

            prov_calib.Text = DatosInforme.datos_proveedor["prov_calib"];
            prov_calib.Visible = true;
            direccion_calib.Text = DatosInforme.datos_proveedor["direccion_calib"];
            direccion_calib.Visible = true;
            telefono_calib.Text = DatosInforme.datos_proveedor["telefono_calib"];
            telefono_calib.Visible = true;
            email_calib.Text = DatosInforme.datos_proveedor["email_calib"];
            email_calib.Visible = true;
            nombre_calib.Text = DatosInforme.datos_proveedor["nombre_calib"];
            nombre_calib.Visible = true;

            //info tecnica
            manual_op.Text = DatosInforme.info_tecnica["manual_op"];
            manual_op.Visible = true;
            manual_inst.Text = DatosInforme.info_tecnica["manual_inst"];
            manual_inst.Visible = true;
            manual_servi.Text = DatosInforme.info_tecnica["manual_servi"];
            manual_servi.Visible = true;
            manual_part.Text = DatosInforme.info_tecnica["manual_part"];
            manual_part.Visible = true;
            otra_lit.Text = DatosInforme.info_tecnica["otra_lit"];
            otra_lit.Visible = true;
            no_existe.Text = DatosInforme.info_tecnica["no_existe"];
            no_existe.Visible = true;

            //estado bien

            estatus.Text = DatosInforme.estado_bien["status"];
            estatus.Visible = true;
            no_operativo.Text = DatosInforme.estado_bien["no_operativo"];
            no_operativo.Visible = true;
            observaciones3.Text = DatosInforme.estado_bien["observaciones"];
            observaciones.Visible = true;

            //accesorios equipo
            primero.Text = DatosInforme.accesorio_equipo["primero"];
            primero.Visible = true;
            segundo.Text = DatosInforme.accesorio_equipo["segundo"];
            segundo.Visible = true;
            tercero.Text = DatosInforme.accesorio_equipo["tercero"];
            tercero.Visible = true;
            cuarto.Text = DatosInforme.accesorio_equipo["cuarto"];
            cuarto.Visible = true;
            quinto.Text = DatosInforme.accesorio_equipo["quinto"];
            quinto.Visible = true;
            sexto.Text = DatosInforme.accesorio_equipo["sexto"];
            sexto.Visible = true;
            estado_pr.Text = DatosInforme.accesorio_equipo["estado_pr"];
            estado_pr.Visible = true;
            estado_se.Text = DatosInforme.accesorio_equipo["estado_se"];
            estado_se.Visible = true;
            estado_te.Text = DatosInforme.accesorio_equipo["estado_te"];
            estado_te.Visible = true;
            estado_cu.Text = DatosInforme.accesorio_equipo["estado_cu"];
            estado_cu.Visible = true;
            estado_qi.Text = DatosInforme.accesorio_equipo["estado_qu"];
            estado_qi.Visible = true;
            estado_sex.Text = DatosInforme.accesorio_equipo["estado_sex"];
            estado_sex.Visible = true;
            observaciones4.Text = DatosInforme.accesorio_equipo["observaciones"];
            observaciones4.Visible = true;

            //otrso datos
           
            garantiabool.Text = True_false(DatosInforme.otros_datos["garantia"]);
            garantiabool.Visible = true;
            contratobool.Text = True_false(DatosInforme.otros_datos["contrato"]);
            contratobool.Visible = true;
            frecuenciaOD.Text = DatosInforme.otros_datos["frecuencia"];
            frecuenciaOD.Visible = true;
            responsable.Text = DatosInforme.otros_datos["responsable"];
            responsable.Visible = true;
            observaciones5.Text = DatosInforme.otros_datos["observaciones"];
            observaciones5.Visible = true;

            //registro de elaboaracion
            nombre_repp.Text = DatosInforme.registro_elab["nombre_resp"];
            nombre_repp.Visible = true;
            cargo.Text = DatosInforme.registro_elab["cargo"];
            cargo.Visible = true;
            telefono.Text = DatosInforme.registro_elab["telefono"];
            telefono.Visible = true;
            email.Text = DatosInforme.registro_elab["email"];
            email.Visible = true;
            firmar.Text = DatosInforme.registro_elab["firmar"];
            firmar.Visible = true;

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

    
    }
}

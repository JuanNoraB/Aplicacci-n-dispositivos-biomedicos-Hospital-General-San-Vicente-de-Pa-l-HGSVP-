using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Dispositivos
{
    public class DatosInforme
    {
        static public string valorQ;

        static public Dictionary<string, string> equip_descriptionD = new Dictionary<string, string>()
        {
                {"tipo_bien", ""},
                {"Nombre_equipo", ""},
                {"Marca", ""},
                {"Modelo", ""},
                {"Serie", ""},
                {"tipo_registro", ""},
                {"fab_year", ""},
        };

        static public Dictionary<string, string> equipo_tdata = new Dictionary<string, string>()
        {
            { "n_serie",""},
            { "n_tipo_registro",""},
            { "vol",""},
            { "fase",""},
            { "corriente",""},
            { "potencia",""},
            { "frecuencia",""},
            { "bateria",""},
            { "channels",""},
            { "memory",""},
            {"printer" , ""},
            { "observaciones",""}
        };
            
        static public Dictionary<string, string> equipo_requirements = new Dictionary<string, string>()
        {
            { "n1_serie",""},
            { "n1_tipo_registro",""},
            { "electrico",""},
            { "med_electrico",""},
            { "mecanico",""},
            { "med_mecanico",""},
            { "electronico",""},
            { "med_electronico",""},
            { "hidraulico",""},
            { "med_hidraulico",""},
            {"neumatico" , ""},
            { "med_neumatico",""},
            { "electromicanico",""},
            { "med_electromicanico",""},
            { "vapor",""},
            { "med_vapor",""},
            { "glp",""},
            { "med_glp",""},
            { "medicinal",""},
            { "med_medicinal",""},
            { "a_comprimido",""},
            { "med_a_comprimido",""},
            { "a_fria",""},
            { "med_a_fria",""},
            { "a_caliente",""},
            { "med_a_caliente",""},
            { "a_descal","med_a_descal"},
            { "otro","med_otro"},
            { "med_otro",""}
        };

        static public Dictionary<string, string> equipo_parameters = new Dictionary<string, string>()
        {
            { "n2_serie",""},
            { "n2_tipo_registro",""},
            { "ecg",""},
            { "spo2",""},
            { "f_cardiaca",""},
            { "eeg",""},
            { "spco",""},
            { "co",""},
            { "o2",""},
            { "apnea",""},
            {"temperatura" , ""},
            { "f_cerebral",""},
            { "f_respiratoria",""},
            { "p_invasiva",""},
            { "arritmia",""},
            { "p_ninvasia",""},
            { "ph",""},
            { "masa",""},
            { "pic",""},
            { "bis",""},
            { "vcv",""},
            { "pcv",""},
            { "simv",""},
            { "peep",""},
            { "psv",""},
            { "mac",""},
            { "no2",""},
            { "fio2",""},
            { "otro",""}

        };

        static public Dictionary<string, string> datos_economicos = new Dictionary<string, string>()
        {
            { "n3_serie",""},
            { "n3_tipo_registro",""},
            { "valor_adq",""},
            { "n_factura",""},
            { "f_adquisicion",""},
            { "fecha",""},
            { "vida_util",""}

        };

        static public Dictionary<string, string> ubicacion_equipo = new Dictionary<string, string>()
        {
            { "n4_serie",""},
            { "n4_tipo_registro",""},
            { "unidad_op",""},
            { "servicio",""},
            { "sub_servicio",""},
            { "nombre_custodio",""},
            { "zona",""},
            { "distrito",""},
            { "provincia",""},
            { "ciudad",""}

        };

        static public Dictionary<string, string> datos_proveedor = new Dictionary<string, string>()
        {
            { "n5_serie",""},
            { "n5_tipo_registro",""},
            { "fabricante",""},
            { "direccion_fab",""},
            { "telefono_fab",""},
            { "email_fab",""},
            { "provedor",""},
            { "direccion_prov",""},
            { "telefono_prov",""},
            { "email_prov",""},
            {"nombre_prov_cont" , ""},
            { "representante_pais",""},
            { "direccion_rep",""},
            { "telefono_rep",""},
            { "email_rep",""},
            { "nombre_rep",""},

            { "prov_manten",""},
            { "direccion_mant",""},
            { "telefono_mant",""},
            { "email_mant",""},
            { "nombre_mant",""},
             
            { "prov_calib",""},
            { "direccion_calib",""},
            { "telefono_calib",""},
            { "email_calib",""},
            { "nombre_calib",""}
            

        };
        
            static public Dictionary<string, string> info_tecnica = new Dictionary<string, string>()
        {
            { "n6_serie",""},
            { "n6_tipo_registro",""},
            { "manual_op",""},
            { "manual_inst",""},
            { "manual_servi",""},
            { "manual_part",""},
            { "otra_lit",""},
            { "no_existe",""}

        };

        static public Dictionary<string, string> accesorio_equipo = new Dictionary<string, string>()
        {
            { "n8_serie",""},
            { "n8_tipo_registro",""},
            { "primero",""},
            { "segundo",""},
            { "tercero",""},
            { "cuarto",""},
            { "quinto",""},
            { "sexto",""},
            { "estado_pr",""},
            { "estado_se",""},
            { "estado_te",""},
            { "estado_cu",""},
            { "estado_qu",""},
            { "estado_sex",""},
            { "observaciones",""},

        };


        static public Dictionary<string, string> estado_bien = new Dictionary<string, string>()
        {
            { "n7_serie",""},
            { "n7_tipo_registro",""},
            { "status",""},
            { "no_operativo",""},
            { "observaciones",""}

        };

        //otros_datos
        static public Dictionary<string, string> otros_datos = new Dictionary<string, string>()
        {
            { "n9_serie",""},
            { "n9_tipo_registro",""},
            { "garantia",""},
            { "contrato",""},
            { "frecuencia",""},
            { "responsable",""},
            { "observaciones",""}

        };

        //registro_elab
        static public Dictionary<string, string> registro_elab = new Dictionary<string, string>()
        {
            { "n10_serie",""},
            { "n10_tipo_registro",""},
            { "nombre_resp",""},
            { "cargo",""},
            { "telefono",""},
            { "email",""},
            { "fecha",""},
            { "firmar",""}

        };
    }
}

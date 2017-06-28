using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Clientes.Models
{
    public class IdDocAttribute : ValidationAttribute
    {
        public override bool IsValid(object idCodeObject)
        {
            var idCode = (string)idCodeObject;
            idCode = idCode.Replace("-", "");
            idCode = idCode.ToUpper();
            switch (idCode[0])
            { //Control de NIE
                case 'X':
                    idCode = idCode.Substring(1);
                    break;
                case 'Y':
                    idCode = "1" + idCode.Substring(1);
                    break;
                case 'Z':
                    idCode = "2" + idCode.Substring(1);
                    break;
            }
            char letraControl = Convert.ToChar(idCode.Substring(idCode.Length - 1));
            Regex testCif = new Regex("^[^0-9]");
            if (testCif.IsMatch(idCode))
            { // es CIF
                string parteNumCif = idCode.Substring(1, 7);
                char control = idCode[idCode.Length - 1];
                int A = Convert.ToInt32(parteNumCif[1]) + Convert.ToInt32(parteNumCif[3]) + Convert.ToInt32(parteNumCif[5]);
                int B = controlDigitoImpar(Convert.ToInt32(parteNumCif[0])) + controlDigitoImpar(Convert.ToInt32(parteNumCif[2])) + controlDigitoImpar(Convert.ToInt32(parteNumCif[4])) + controlDigitoImpar(Convert.ToInt32(parteNumCif[6]));
                int C = A + B;
                int digitoControl;
                if (C % 10 == 0)
                {
                    digitoControl = 0;
                }
                else
                {
                    digitoControl = 10 - (C % 10);
                }
                string letrasControlCif = "JABCDEFGHI";

                if (control == Convert.ToChar(digitoControl) || control == letrasControlCif[digitoControl])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { //Es DNI
                string parteNumDni = idCode.Substring(0, idCode.Length - 1);
                int intNumDni = Convert.ToInt32(parteNumDni);
                string letrasControlDni = "TRWAGMYFPDXBNJZSQVHLCKE";
                int resto = intNumDni % 23;
                if (letraControl == letrasControlDni[resto])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /* Función complementaria para validarNif a comprobar si el digito es impar */
        private static int controlDigitoImpar(int numero)
        {
            int num = numero * 2;
            if (num > 9)
            {
                decimal decena = num / 10;
                return (int)Math.Truncate(decena) + num % 10;
            }
            else
            {
                return num;
            }
        }

        /* Función para rellenar de 0 , los digitos que falten del dni. Devuelve el dni formateado. */
        private static string rellenarCeros(string dni)
        {
            if (dni.Length < 9)
            {
                dni = rellenarCeros(String.Format("{0}{1}", "0", dni));
            }
            return dni;
        }
    }
}
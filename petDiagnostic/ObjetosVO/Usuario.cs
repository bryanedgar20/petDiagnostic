using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace petDiagnostic.ObjetosVO
{
    public class Usuario
    {
        private int idUsuario;

        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private Date fechaNacimiento;
        private string identificacion;
        private string email;
        private string numeroTelefono;
        private string callePrincipal;
        private string calleSecundaria;
        private string nickName;
        private string clave;

        private string estado;
        private Date fechaRegistro;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public Date FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Email { get => email; set => email = value; }
        public string NumeroTelefono { get => numeroTelefono; set => numeroTelefono = value; }
        public string CallePrincipal { get => callePrincipal; set => callePrincipal = value; }
        public string CalleSecundaria { get => calleSecundaria; set => calleSecundaria = value; }
        public string NickName { get => nickName; set => nickName = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Estado { get => estado; set => estado = value; }
        public Date FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}

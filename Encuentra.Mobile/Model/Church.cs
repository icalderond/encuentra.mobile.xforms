using System;
namespace Encuentra.Mobile.Model
{
    public class Church
    {
        public string nombre
        {
            get;
            set;
        }
        public string edo
        {
            get;
            set;
        }
        public string cd
        {
            get;
            set;
        }
        public string colonia
        {
            get;
            set;
        }
        public string calle
        {
            get;
            set;
        }
        public string no
        {
            get;
            set;
        }
        public string foto
        {
            get;
            set;
        }
        public string latitud
        {
            get;
            set;
        }
        public string longitud
        {
            get;
            set;
        }
        public string direccion
        {
            get => $"{cd}, {colonia}";
        }
        //public override string ToString()
        //{
        //    return $"{cd}, {colonia}";
        //}
    }
}

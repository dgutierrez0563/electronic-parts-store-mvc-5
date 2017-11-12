using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electronic_store.Models
{
    public class ShopCar
    {
        private Producto _producto;
        private int _cantidad;

        public Producto Producto
        {
            get
            {
                return _producto;
            }

            set
            {
                _producto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;
            }
        }

        public ShopCar() { }

        public ShopCar(Producto producto, int cantidad) {
            this._producto = producto;
            this._cantidad = cantidad;
        }
    }
}
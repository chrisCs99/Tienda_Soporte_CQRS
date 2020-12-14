using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ServiceOrderHasProductsDTO
    {
        public Guid ServiceOrdersHasProductsId { get; set; }
        public ServiceOrder ServiceOrder { get; set; }
        public Product Product { get; set; }

        public ServiceOrderHasProductsDTO()
        {
        }

        public ServiceOrderHasProductsDTO(Guid serviceOrdersHasProductsId, ServiceOrder serviceOrder, Product product)
        {
            ServiceOrdersHasProductsId = serviceOrdersHasProductsId;
            ServiceOrder = serviceOrder;
            Product = product;
        }
    }
}

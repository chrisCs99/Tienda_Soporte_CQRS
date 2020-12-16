    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class ServiceOrderDetailDTO
    {
        public Guid ServiceOrderDetailId { get; set; }
        public int ServiceType { get; set; }
        public Double Price { get; set; }
        public ServiceOrderDTO ServiceOrder { get; set; }
        public string Description { get; set; }
        public string AlternativeAddress { get; set; }
        public List<ProductDTO> Products { get; set; }

        public ServiceOrderDetailDTO()
        {
        }

        public ServiceOrderDetailDTO(Guid serviceOrderDetailId, int serviceType, double price, string description, string alternativeAddress)
        {
            ServiceOrderDetailId = serviceOrderDetailId;
            ServiceType = serviceType;
            Price = price;
            Description = description;
            AlternativeAddress = alternativeAddress;
        }
    }
}

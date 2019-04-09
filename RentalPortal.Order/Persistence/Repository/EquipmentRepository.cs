using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalPortal.Order.Data;
using RentalPortal.Order.DTO;
using RentalPortal.Order.Entities;
using RentalPortal.Order.Persistence.Repository.Interfaces;

namespace RentalPortal.Order.Persistence.Repository
{
    public class EquipmentRepository : Repository<Equipment, EfDbContext>, IEquipmentRepository
    {
        public EquipmentRepository(EfDbContext context) : base(context)
        {
        }

        public async Task<List<EquipmentDto>> GetAllEquipmentsAsync()
        {
            var data = from equipment in Context.Equipment
                orderby equipment.Name descending
                select new EquipmentDto
                {
                    Name = equipment.Name,
                    EquipmentId = equipment.EquipmentId,
                    EquipmentType = equipment.EquipmentType
                };
            return await data.AsNoTracking().ToListAsync();
        }

        public async Task<int> EquipmentCount(int productId)
        {
            int counter = 0;
            var data=Context.Equipment.Where(x => x.EquipmentId == productId);
            if (data.Any())
            {
                return await data.CountAsync();
            }
            return counter;
        }
    }
}

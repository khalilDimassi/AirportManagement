using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : IServicePlane
    {

        /* *************************************** generic repository ******************************** */
        IGenericRepository<Plane> GenericRepository_;

        public ServicePlane(IGenericRepository<Plane> genericRepository)
        {
            GenericRepository_ = genericRepository;
        }

        public void add(Plane plane)
        {
            GenericRepository_.InsertEntity(plane);
        }

        public List<Plane> GetAll()
        {
            return GenericRepository_.GetAll().ToList();
        }

        public void remove(Plane plane)
        {
            GenericRepository_.DeleteEntity(plane);
        }

        /* *************************************** unit of work ******************************** */
        public IUnitOfWork _unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(Plane p)
        {
            _unitOfWork.Repository<Plane>().InsertEntity(p);
        }

        public void Update(Plane f)
        {
            _unitOfWork.Repository<Plane>().UpdateEntity(p);
        }

        public IList<Plane> getAll()
        {
            return _unitOfWork.Repository<Plane>().GetAll().ToList();
        }
    }
}

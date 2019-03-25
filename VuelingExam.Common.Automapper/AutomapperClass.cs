using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Common.Automapper
{
    public class AutomapperClass
    {
        /* public T GetObjectMapping<T, Y> (Y model) {
            var automappingConfiguration = new ...
           }
        */

        public U Map<T,U>(T origin)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, U>());
            IMapper mapper = config.CreateMapper();

            return mapper.Map<T, U>(origin);
        }

        public List<U> Map<T, U>(List<T> origin)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<List<T>, List<U>>());
            IMapper mapper = config.CreateMapper();

            return mapper.Map<List<T>,List<U>>(origin);
        }
    }
}

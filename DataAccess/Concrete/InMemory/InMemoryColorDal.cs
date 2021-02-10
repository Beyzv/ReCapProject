using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName="Gri"},
                new Color{ColorId=2, ColorName="Siyah"},
                new Color{ColorId=3, ColorName="Beyaz"},
                new Color{ColorId=4, ColorName="Kırmızı"}

            };
        }
        public void Add(Color color)
        {
           _colors.Add(color);
        }

        public void Delete(Color entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == entity.ColorId);

            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colors;
        }

        public void Update(Color entity)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == entity.ColorId);
            colorToUpdate.ColorName = entity.ColorName;
            colorToUpdate.ColorId = entity.ColorId;
        }
    }
}

using MagicVilla.Models;
using MagicVilla.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MagicVilla.Controllers
{
    [ApiController]
    [Route("/api/VillaApi")]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillasDtos>> GetVillas()
        {
            return Ok(villastore.villalist);

        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillasDtos> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }            
            var villa =  villastore.villalist.FirstOrDefault(i=>i.Id == id);

            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillasDtos> AddVilla([FromBody]VillasDtos villa)
        {
            if (villa.Id > 0)
            {
                return BadRequest();
            }
            villa.Id = villastore.villalist.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            villastore.villalist.Add(villa);
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            VillasDtos villas = villastore.villalist.Find(i => i.Id == id);
            villastore.villalist.Remove(villas);
            return Ok(villas);
        }

        [HttpPut]
        public ActionResult UpdateVilla(VillasDtos villa)
        {
            VillasDtos vd = new VillasDtos();
            vd = villastore.villalist.Find(i=>i.Id == villa.Id);
            vd.Name = villa.Name;
            villastore.villalist.RemoveAt(vd.Id);
            villastore.villalist.Add(vd);
            return Ok(vd);
        }
    }
}

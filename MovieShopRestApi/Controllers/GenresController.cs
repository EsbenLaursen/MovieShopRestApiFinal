using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDll.Entities;
using MovieShopDll;

namespace MovieShopRestApi.Controllers
{
    public class GenresController : ApiController
    {
        IRepository<Genre> gr = new DllFacade().GetGenreRepository();

        // GET: api/Genres
        public List<Genre> GetGenres()
        {
            List<Genre> genres = gr.Read();
            return genres;
        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = gr.Read(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest("ids did not match");
            }

            gr.Update(genre);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gr.Create(genre);

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = gr.Read(id);
            if (genre == null)
            {
                return NotFound();
            }

            gr.Delete(id);

            return Ok(genre);
        }
    }
}
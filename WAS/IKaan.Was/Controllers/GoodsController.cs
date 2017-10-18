using System.Web.Mvc;
using IKaan.Base.Map;
using IKaan.Was.Service.Services;

namespace IKaan.Was.Controllers
{
	public class GoodsController : Controller
    {
        // GET: Goods
		[HttpPost]
        public ActionResult Index(string FindText, string GoodsCode, string GoodsName, string CategoryID, string BrandID, string Age, string Gender, string Season, string Origin, string UseYn)
        {
			DataMap map = new DataMap()
			{
				{ "FindText", FindText },
				{ "GoodsCode", GoodsCode },
				{ "GoodsName", GoodsName },
				{ "CategoryID", CategoryID },
				{ "BrandID", BrandID },
				{ "Age", Age },
				{ "Gender", Gender },
				{ "Season", Season },
				{ "Origin", Origin },
				{ "UseYn", UseYn }
			};

			var model = BizServiceCatalog.GetProductList(map);
            return View("GoodsList", model);
        }

        // GET: Goods/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goods/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

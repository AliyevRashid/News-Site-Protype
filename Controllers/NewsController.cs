using Microsoft.AspNetCore.Mvc;
using NewsApplication.DTO;
using NewsApplication.Services;

namespace NewsApplication.Controllers;

public class NewsController : Controller
{
    private INewsItemService _newsItemService;

    public NewsController(INewsItemService newsItemService)
    {
        _newsItemService = newsItemService;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _newsItemService.GetNewsItems();
        return View(items.ToList());
    }

    public IActionResult Create()
    {
        return View("CreateNewsItem");
    }


  [HttpPost] 
    public  IActionResult Create(CreateNewsItemRequestDto request)
    {
        var item =  _newsItemService.CreateNewsItem(request);
        return RedirectToAction("Index");
    }
    public IActionResult Details()
    {
        return View("Details");
    }
   [HttpGet]
    public async Task<IActionResult> Details(string title) 
    {
        var item = await _newsItemService.GetNewsItemByTitle(title);
        return View(item);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string title)
    {
        await _newsItemService.DeleteNewsItem(title);
        return RedirectToAction("Index");

    }

    public IActionResult Edit()
    {
        return View("EditNewsItem");
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditNewsItemRequestDto editRequest)
    {
        if (editRequest == null)
        {
            return BadRequest("editRequest is null");
        }
        await _newsItemService.EditNewsItem( editRequest);
        return RedirectToAction("Index");
    }
}

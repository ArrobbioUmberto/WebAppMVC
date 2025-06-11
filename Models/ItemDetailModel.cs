using WebAppMVC.Models.Value;

namespace WebAppMVC.Models
{

    public class ItemDetailModel : ItemViewModel
    {
        public ItemViewModel Product { get; set; } = new ItemViewModel();
        public List<ItemViewModel> Related { get; set; } = new List<ItemViewModel>();
    }


}
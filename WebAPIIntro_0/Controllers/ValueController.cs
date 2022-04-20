using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIIntro_0.Controllers
{

    #region Notlar
    //MVC projelerinde bir Action'in basına bir HTTP attribute'u koymadıgımız takdirde bu Action'in default request'i Get olarak algılanır...

    //API projelerinde ise bu yöntemlerin özellikle yazılması gerekir...Yoksa Action tanınmaz...Tek istisnası (bu yöntemi yapmadıgınız halde Action'in request ile ulasılabilmesinin tek istisnası) bu yöntemin isminin (Get,Post vs) Action isminin basına yazılmasıdır...

    //Eger HTTP yöntemini bir attribute olarak tanımlamak istemezseniz o zaman yöntem adlarınızın(Get,Post,Put,Delete) Action isminin basına yazılmasına Conventional Basing Route yöntemi denir...

    //Dikkat ederseniz API'da aynı zamanda URL template'inin varsayılan hali de degişiktir...Sizden MVC gibi bir Action ismi istemez...


    /*
     * 
     * Get:Bir sayfanın yeni olarak istenmesidir(Siz url'den aynı sayfası isteseniz bile o aslında yepyeni bir istektir)
     * Post: Size gelmiş olan bir sayfanın tekrar server'a geri gönderilmesidir(API'da özellikle sadece ekleme işlemleri icin kullanılır...Teknik olarka Post yönteminde günceleme yapabiliyor olsanız da API'da güncelleme icin Post saglıklı degildir...)
     * Put: API'da güncelleme işlemleri icin tercih edilir
     * Delete: API'da silme işlemleri icin tercih edilir
     
     
     
     
     
     
     */


    #endregion





    public class ValueController : ApiController
    {

        static List<string> _sehirler = new List<string>
        {
            "Istanbul","Ankara","İzmir","Yalova","Erzincan","Mersin"
        };



        [HttpGet]
        public List<string> ListCities()
        {
            return _sehirler;
        }

        [HttpGet]
        public List<string> ListReverseCities()
        {
            _sehirler.Reverse();
            return _sehirler;
        }

        [HttpGet]
        public string BringCityByIndex(int id)
        {
            return _sehirler[id];
        }

        [HttpPost]
        public List<string> AddCity(string item)
        {
            _sehirler.Add(item);
            return _sehirler;
        }

        [HttpDelete]
        public List<string> RemoveCity(string item)
        {
            _sehirler.Remove(item);
            return _sehirler;
        }

        [HttpPut]
        public List<string> UpdateCity(int index,string newValue)
        {
            _sehirler[index] = newValue;
            return _sehirler;
        }



    }
}

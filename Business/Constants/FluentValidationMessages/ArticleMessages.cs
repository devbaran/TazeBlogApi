using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.FluentValidationMessages;
public static class ArticleMessages
{

    public static string NullId = "Id boş olamaz.";
    
    public static string ArticleTitleNull = "Makale başlığı boş olamaz.";
    public static string ArticleTitleMinLenght = "Makale başlığı en az 4 karakterli olmalı.";
    public static string ArticleTitleMaxLenght = "Makale başlığı en fazla 140 karakterli olmalı.";

    public static string ArticleContentNull = "Makale içeriği boş olamaz.";
    public static string ArticleContentMinLenght = "Makale içeriği en az 140 karakterli olmalı.";

    public static string ArticleDateNull = "Makale tarihi boş olamaz.";

    public static string ArticleStatusNull = "Status boş olamaz, true veya false verilmeli.";
}

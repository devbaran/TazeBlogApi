using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.FluentValidationMessages;
public static class CategoryMessages
{
    public static string NameNull = "Kategori adı boş olamaz.";
    public static string NameMinLenght = "Kategori adı en az 4 karakterli olmalı.";
    public static string NameMaxLenght = "Kategori adı en fazla 99 karakterli olmalı.";

    public static string DescriptionNull = "Açıklama boş olamaz.";
    public static string DescriptionMinLenght = "Açıklama en az 4 karakterli olmalı.";
    public static string DescriptionMaxLenght = "Açıklama en fazla 199 karakterli olmalı.";

    public static string StatusNull = "Status boş olamaz, true veya false verilmeli.";
}

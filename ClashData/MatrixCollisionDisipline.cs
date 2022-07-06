using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashData
{
    class MatrixCollisionDisipline
    {
        public string Displine1 { get; set; } = new string(new char[] { });
        public string Displine2 { get; set; } = new string(new char[] { });

        public MatrixCollisionDisipline(string Displine)
        {
            var listDispline = Displine.Split('_');
            var nameCheck = listDispline.Last();
            var listCheck = nameCheck.Split('+').Select(x => x.Trim()).ToList();

            Displine1 = caseDiscipline(listCheck[0]);
            Displine2 = caseDiscipline(listCheck[1]);
        }

        private string caseDiscipline(string discipline)
        {
            var result = new string(new char[] { });

            var caseDefault = "0. Не определено";
            switch (discipline)
            {
                case "АР ст":
                    result = "1. АР Стены";
                    break;

                case "АР пл":
                    result = "2. АР Полы";
                    break;

                case "АР пт":
                    result = "3. АР Потолки";
                    break;

                case "АР дв":
                    result = "4. АР Двери";
                    break;

                case "КР ст":
                    result = "5. КР Несущие стены";
                    break;

                case "КР пр":
                    result = "6. КР Перекрытия";
                    break;

                case "КР кл":
                    result = "7. КР Колонны";
                    break;

                case "КР нк":
                    result = "8. КР Несущий каркас";
                    break;

                case "ОВ от обр":
                    result = "9. ОВ (отопление) Оборудование";
                    break;

                case "ОВ от трб":
                    result = "10. ОВ (отопление) Трубы";
                    break;

                case "ОВ вен обр":
                    result = "11. ОВ (вентиляция) Оборудование";
                    break;

                case "ОВ вен воз":
                    result = "12. ОВ (вентиляция) Воздуховоды";
                    break;

                case "ВК обр":
                    result = "13. ВК Оборудование";
                    break;

                case "ВК тр":
                    result = "14. ВК Трубы";
                    break;

                case "ЭОМ св":
                    result = "15. ЭОМ Светильники";
                    break;

                case "ЭОМ шк":
                    result = "16. ЭОМ Щиты/Шкафы";
                    break;

                case "ЭОМ обр":
                    result = "17. ЭОМ Оборудование";
                    break;

                case "ЭОМ кк":
                    result = "18. ЭОМ Кабельные конструкции";
                    break;

                default:
                    result = caseDefault;
                    break;
            }

            return result;
        }
    }
}

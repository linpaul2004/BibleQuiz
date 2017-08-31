using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BibleQuiz
{
	public partial class Form1 : Form
	{
		Button[] buttons = new Button[9];
		int press;
		Random r = new Random();
		string[][] question = new string[][]{
			new string[]{ "成語「病入膏肓」當中的膏指的是心臟，而肓指的是？", "成語「直搗黃龍」中的「黃龍」指的是？", "明月幾時有？把酒問青天。是誰的詩詞？", "「唐詩三百首」是由哪個朝代的人所編輯的？", "何者不是4大名著之一？", "成語「東施效顰」中的「顰」是指哪一個動作？", "「人生以服務為目的」這句話是哪個偉人說的？", "「悄悄地揮一揮手，不帶走一片雲彩」的是詩人", "網路上流行的「囧」字，正確的意思是什麼？", "用來形容色彩鮮豔奪目的五彩繽紛，當中的「五彩」原本是指？", "「詩豪」意指何人？","六畜興旺中的「六畜」是指哪六種？","請問四書五經中的四書為何？", "「執子之手，與子偕老」的出處？", "「知天命」代指什麼年紀？","「東床快婿」原本是指誰","被稱為「書聖」的古代書法家為" },
			new string[]{ "哥哥6歲時，妹妹的年齡是他的一半，請問哥哥50歲時妹妹幾歲？", "所謂的一刻鐘是指？", "六角柱比六角錐多幾個面？", "在數學上，幾個邊以上的平面圖形，都叫做「多邊形」？", "1KG的鐵塊跟1KG的羽毛何者比較重？", "自來水公司以「度」來計算水量，1度等於多少立方公尺的水？", "平行四邊形的每一個邊都可以叫做？", "在除法計算中，餘數一定大於除數？", "單車環島一週約1300公里 ，若每天騎6小時，每小時騎8公里，約幾天可以完成環島？", "有20隻雞跟兔子，只知道他們有54隻腳，請問雞跟兔各有幾隻？" },
			new string[]{ "下雨天時總是先看到閃電才聽到雷聲，那是因為？", "在月球上十公斤重的人，回到地球上會是幾公斤？", "大肚魚是用什麼方式繁殖的？", "彈塗魚在陸上活動時，是用什麼在呼吸？", "氣象局在預測24小時累積雨量時到達多少毫米，就會發布「大豪雨特報」？", "ㄧ天當中的哪個時候，公園的空氣「含氧量」最高？", "正常人體體細胞有多少條染色體？", "小蜜蜂跳著8字舞是想告訴同伴，香甜的蜂蜜就在？", "蜘蛛會吐絲結網捕捉獵物，那他所吐的絲其實是？", "水蠆(ㄔㄞˋ)是哪一種昆蟲的小時候？","豬籠草和毛氈苔主要藉由捕食昆蟲以獲得該地區缺乏的何種營養素？","當天空出現彎曲彩虹的時候最外層的顏色是？","地球與太陽之間的距離有多少公里？","地殼中含量最高的元素是？" },
			new string[]{ "台灣最小的市是「台北永和」，請問下列選項中最小的鄉鎮是哪裡？", "請以北至南依序排列台灣名山？", "台語的「胖」指的是麵包，這個發音最早原自？", "小明一家人想去洗世界上少有的海底溫泉，她們應該去哪裡？", "台灣諺語頂港有名聲，下港有出名請問頂港、下港是用什麼來分界？", "稱為「玫瑰之國」的國家為何者？", "世界上地勢最低的國家是：","請問石灰岩地形又稱為什麼地形？","巴西的首都是哪座城市？" },
			new string[]{ "請問2次世界大戰中的軸心國成員為哪3國？", "請問一日三餐是從何時開始？", "「五十步笑百步」出自：","請問八國聯軍為哪八國？","在古希臘，象徵婚姻幸福的標誌是一個什麼形狀？","「地動儀」是誰製作的？","台灣有「福爾摩沙」之稱，是當初哪一國人說出的？" },
			new string[]{ "捷運的英文縮寫是MRT，那請問捷運的英文全名是什麼？", "白雪公主叫Snow White，請問白馬王子叫什麼？", "The sun rises ___ the east. 空格處應填入？", "Sheep feed ___ grass.中間應填入？", "Ketchup的意思是什麼？", "海綿寶寶最愛的寵物是誰？", "媽咪是許多人對媽媽的暱稱，以下何者是美式媽咪的正確拼字？", "以下哪個選項屬於人體「器官」？", "被踩到腳時，中文我們會說「哎喲」，英文該怎麼說？", "以下哪一個數字最大？","請說出五種電器的英文" },
			new string[]{ "在速限時速50公里以下路段，發生汽車車禍，應將三角警告牌放在車輛後方幾公尺？", "迪士尼經典卡通人物米老鼠養的寵物叫什麼名字？", "人人愛用的FACEBOOK請問成立於何時？", "「紫外線指數」的英文縮寫是什麼？", "以下哪些作品不是宮崎駿的作品？", "教育部至2010年開始訂有「祖父母節」，請問是哪一天？", "人民的保母－警察，他身上配戴的階級胸章位在？", "ＣＰＲ練習對象「甦醒安妮」，她的名稱由來是因為發明者？", "如果把一個成人的全部血管連接起來，其長度接近多少公里？", "飛沫傳染是一種直接傳染途徑，以下哪種疾病不是經由飛沫傳染？","華氏溫標規定，一個標準大氣壓下，純水的沸點為","聯合國旗幟圖案是一雙橄欖枝襯托著整個地球，這一圖案取材於哪個故事？","珊瑚婚是指結婚多少周年？" },
			//
			new string[]{ "排球1895年始於哪個國家？", "請問NBA籃球規則中規定個人犯規幾次即畢業離場？", "職籃規則中規定，團隊犯規每節超過幾次則要罰球兩次？", "桌球比賽中發球觸網球有過則？", "排球比賽中隊伍上有位身穿不同顏色衣服的球員為何？", "請問棒球比賽中游擊手代號為何？", "請問飛盤比賽中一隊正規出場先發有幾人", "躲避球規則中球員接到球後必須幾秒內出手？", "女排的球網有多高？", "跑步比賽被喻為世界最快的男人請問是何者？", "請問奧運五環為哪五色", "請問2004年奧運在哪裡舉辦？","鐵人三項比賽中，自行車項目的距離為幾公里？" },
			new string[]{ "請問網球王子中的無我堂奧的三道門是哪三道？" },
			new string[]{ "請問野原廣志所待的公司為何？" },
			new string[]{ "請問「扇子」的台語如何念？" },
			new string[]{ "來自美國的哪個政治術語，指以不公平的選區劃分方法操縱選舉，致使投票結果有利於某方？" },
			//
			new string[]{ "請問教會有哪幾個牧區？", "這次活動總召為下列何者？", "請問富強教會現在幾歲？", "請問富強教會地址？", "請問富強教會何時設立？", "請列舉教會5位現任執事？", "教會的電話是？", "聖歌隊的譜務室的位置？", "提摩太牧區年度目標？", "請說出提摩太牧區所有的小組名" },
			new string[]{ "請列舉4封保羅寫的書信名稱", "聖經的創世紀是神感動誰寫的？", "請說出一對舊約中雙胞胎名字", "摩西的姐姐和哥哥叫什麼名字？", "請說出舊約中的4位先知名字", "舊約和新約之間隔了大約幾百年？", "舊約的傳道書後面是哪一卷書？", "請列舉4個聖經中提到的地名", "請列舉舊約中4個國王的名字", "請列舉耶穌門徒的名字，舉一個得一分，錯兩個以上開始倒扣", "耶穌在十字架上斷氣前說的最後一句話是？" },
			//
			//卡通
			new string[]{ "「獵人」卡通中，測試念能力的方法為何？", "神隱少女中的湯婆婆的寶寶，後來變成什麼動物？", "哆啦A夢身上的鈴鐺其功用為何？", "Mickey Mouse的生日是幾號？" },
			//遊戲
			new string[]{ "請問初代超級瑪利總共有幾關？", "英雄聯盟中，曾在S2拿下冠軍的隊伍是？" },
			//電影
			new string[]{ "「做人如果沒夢想，跟鹹魚有什麼分別」出自？", "海角七號中的日本男歌手名字為何？", "電影「失落的帝國」是以哪一個古文明背景拍攝的？" },
			//時事
			new string[]{ "請問今年在舉重58公斤級以抓舉107公斤、挺舉142公斤，總和249公斤，拿下我國本屆世大運舉重金牌，並在挺舉項目打破世界紀錄的台灣女將是誰？", "一週以來，毒雞蛋風波持續檢出____成分超標。台灣食品安全促進協會理事長姜至剛也強調，_____超標不是中毒。請問近日毒雞蛋風波所含超標之成分為何？", "何人有「旋渦老人」之稱？" },
			//美術
			new string[]{ "請問下列何者並非色光三原色？", "請問畢卡索為哪一個畫派？", "在文學界，但丁、佩脫拉克、薄伽丘，被稱為「文壇三傑」。在藝術界，15世紀後期至16世紀前半期，義大利文藝復興運動達到鼎盛，出現了「美術三傑」。請問下列何者並非藝術界的「文藝復興三傑」？", "被稱為「交響樂團的心臟」的是", "被稱為「第七藝術」的是" },
			//神隱少女
			new string[]{ "請問劇中白龍的原本名字是？" }
			
		};
		string[][] option = new string[][]{
			new string[]{ "(1)肺\n(2)肝\n(3)橫隔膜", "(1)一個土塵\n(2)一個車營\n(3)一個都城", "(1)李白\n(2)白居易\n(3)蘇東坡\n(4)杜甫", "(1)唐朝\n(2)宋朝\n(3)清朝", "(1)紅樓夢\n(2)三國演義\n(3)西遊記\n(4)水滸傳","", "(1)孫中山\n(2)蔣中正\n(3)胡適", "(1)徐志摩\n(2)舒婷\n(3)席慕容\n(4)北島", "(1)光輝明亮\n(2)出糗尷尬\n(3)風和日麗","(1)紅、黃、白、黑、青\n(2)藍、青、黃、紅、黑\n(3)黃、紅、紫、青、白", "(1)王維\n(2)王昌齡\n(3)李賀\n(4)劉禹錫","","","(1)詩經\n(2)春秋\n(3)楚辭\n(4)孟子","(1)20歲\n(2)70歲\n(3)30歲\n(4)50歲","(1)司馬相如\n(2)劉邦\n(3)諸葛亮\n(4)王羲之","(1)柳宗元\n(2)顏真卿\n(3)王羲之\n(4)歐陽修" },
			new string[]{ "","(1)15分鐘\n(2)30分鐘\n(3)一小時","","", "(1)鐵塊\n(2)羽毛\n(3)一樣重","", "(1)底\n(2)高\n(3)寬","","","" },
			new string[]{ "(1)閃電是雷的前導預兆\n(2)光速比音速快\n(3)視覺較聽覺敏銳","", "(1)胎生\n(2)卵生\n(3)卵胎生","", "(1)200毫米 以上\n(2)300毫米 以上\n(3)350毫米 以上", "(1)清晨\n(2)中午\n(3)傍晚", "(1)36條\n(2)48條\n(3)46條\n(4)38條", "(1)眼前不遠處\n(2)100公尺內\n(3)100公尺外", "(1)腹部的黏液\n(2)嘴裡的口水\n(3)前肢紡絲器黏液", "(1)蜻蜓\n(2)蚊子\n(3)蒼蠅","(1)鐵\n(2)氮\n(3)鉀\n(4)碳","(1)紫色\n(2)黃色\n(3)紅色\n(4)橙色","(1)一億\n(2)五千萬\n(3)二億五千萬\n(4)一億五千萬","" },
			new string[]{ "(1)苗栗 公館鄉\n(2)雲林 虎尾鎮\n(3)宜蘭 羅東鎮", "(1)合歡山\n(2)八卦山\n(3)鐵山\n(4)半屏山", "(1)日語\n(2)西班牙語\n(3)葡萄牙語", "(1)澎湖\n(2)蘭嶼\n(3)綠島", "(1)大安溪\n(2)大甲溪\n(3)濁水溪", "(1)奈及利亞\n(2)保加利亞\n(3)匈牙利", "(1)芬蘭\n(2)冰島\n(3)挪威\n(4)荷蘭","","(1)里約\n(2)熱內盧\n(3)巴西利亞\n(4)聖保羅紐約" },
			new string[]{"", "(1)秦朝\n(2)唐朝\n(3)宋朝\n(4)明朝", "(1)三國志\n(2)孟子\n(3)晏子春秋\n(4)三國演義","","(1)正方形\n(2)五角星\n(3)心形\n(4)三角形","(1)張儀\n(2)張章\n(3)張衡\n(4)張良","(1)西班牙人\n(2)葡萄牙人\n(3)美國\n(4)中國人" },
			new string[]{"","", "(1)on\n(2)from\n(3)in", "(1)by\n(2)in\n(3)on", "(1)番茄醬\n(2)投手\n(3)帆船", "(1)Snail\n(2)Owl\n(3)Jellyfish", "(1)mammy\n(2)mummy\n(3)mommy", "(1)thick\n(2)chick\n(3)chin", "(1)Whee!\n(2)Oops!\n(3)Ouch!", "(1)million\n(2)trillion\n(3)billion","" },
			new string[]{ "(1)10公尺\n(2)20公尺\n(3)30公尺","", "(1)2004年2月\n(2)2004年3月\n(3)2004年4月\n(4)2005年3月","", "(1)千與千尋的神隱\n(2)龍貓\n(3)紅髮少女安妮\n(4)天空的守護神","", "(1)右邊口袋上方\n(2)左邊口袋上方\n(3)左領口", "(1)自己叫安妮\n(2)太太叫安妮\n(3)女兒叫安妮", "(1)10\n(2)1000\n(3)10000\n(4)10萬", "(1)腮腺炎\n(2)禽流感\n(3)鼠疫","(1)32度\n(2)212度\n(3)180度\n(4)120度","(1)潘朵拉的盒子\n(2)諾亞方舟\n(3)阿喀斯的腳後跟\n(4)達摩克利斯之劍","(1)10\n(2)25\n(3)35\n(4)40" },
			//
			new string[]{ "(1)日本\n(2)英國\n(3)荷蘭\n(4)美國", "(1)三次\n(2)四次\n(3)五次\n(4)六次", "(1)四次\n(2)五次\n(3)六次\n(4)七次", "(1)對方得分\n(2)重新發球\n(3)繼續比賽","", "(1)DH\n(2)SS\n(3)3B\n(4)P", "(1)5人\n(2)6人\n(3)7人\n(4)8人", "(1)3秒\n(2)4秒\n(3)5秒\n(4)6秒", "(1)2.15m\n(2)2.34m\n(3)2.24m\n(4)2.25m","","","","(1)30\n(2)20\n(3)10\n(4)40" },
			new string[]{""},
			new string[]{""},
			new string[]{""},
			new string[]{""},
			//
			new string[]{"", "(1)詠丞\n(2)智祈\n(3)岳錡哥\n(4)郁郁姐","","","","","","","","" },
			new string[]{"","","","","","","","","","",""},
			//
			//卡通
			new string[]{"", "(1)老鼠\n(2)烏鴉\n(3)蜘蛛", "(1)召集附近的貓\n(2)驅趕老鼠\n(3)沒有功能", "(1)8月18日\n(2)11月18日\n(3)9月18日\n(4)10月18日" },
			//遊戲
			new string[]{ "(1)8關\n(2)16關\n(3)32關", "(1)TPA\n(2)AHQ\n(3)FW\n(4)SKT" },
			//電影
			new string[]{ "(1)少林足球\n(2)食神\n(3)九品芝麻官\n(4)賭聖","", "(1)亞特蘭提斯\n(2)波斯\n(3)瑪雅\n(4)埃及","" },
			//時事
			new string[]{ "(1)鄭怡靜\n(2)洪萬庭\n(3)郭婞淳\n(4)陳思羽", "(1)戴奧辛\n(2)百治磷\n(3)甲基硫化胂\n(4)芬普尼", "(1)柯文哲\n(2)馬英九\n(3)陳水扁\n(4)蔡英文" },
			//美術
			new string[]{ "(1)紅\n(2)黃\n(3)藍\n(4)綠", "(1)印象派\n(2)野獸派\n(3)立體派\n(4)抽象派", "(1)笛卡爾\n(2)米開朗基羅\n(3)拉斐爾\n(4)達文西", "(1)弦樂器\n(2)管樂器\n(3)打擊樂器\n(4)都不是", "(1)戲劇\n(2)文學\n(3)電影\n(4)雕塑" },
			//神隱少女
			new string[]{""}
		};
		string[][] answer = new string[][]{
			new string[]{ "(3)橫隔膜", "(3)一個都城", "3", "(3)清朝", "1", "皺眉", "(1)孫中山", "1", "(1)光輝明亮","(1)紅、黃、白、黑、青", "2", "豬、牛、馬、羊、狗、雞", "論語、孟子、大學、中庸","1","4","4","3"},
			new string[]{ "47歲", "(1)15分鐘", "1個面", "3個", "(3)一樣重", "1立方公尺", "(1)底", "Ｘ", "28天", "雞13、兔子7"},
			new string[]{ "(2)光速比音速還快", "60公斤", "(3)卵胎生", "皮膚", "200毫米以上", "(3)傍晚", "3", "(3)100公尺外","(1)腹部的黏液","(1)蜻蜓","2","1","4","鋁"},
			new string[]{ "(3)宜蘭 羅東鎮", "4 2 1 3", "(3)葡萄牙語", "(3)綠島", "(3)濁水溪", "2", "4", "喀斯特地形","2"},
			new string[]{ "德國、日本、義大利", "3", "2", "俄、德、法、美、日、奧、義、英", "4","3","2"},
			new string[]{ "Mass Rapid Transit", "Prince Charming", "(3)in", " (3)on", "(1)番茄醬", "(1)Snail", "(3)mommy", "(3)chin\n下巴", "(3)Ouch", "(2)trillion",""},
			new string[]{ "(3)30公尺", "布魯托", "1", "ＵＶＩ", "4", "8月第四個周日", "(1)右邊口袋上方", "(3)女兒叫安妮", "4", "(2)禽流感","2","2","3"},
			//
			new string[]{"4","4","2","2", "自由球員", "2","3","3","3", "USAINT BOLT", "黑黃紅藍綠", "希臘雅典","4"},
			new string[]{"百鍊自得、才華洋溢、天衣無縫"},
			new string[]{"雙葉商事"},
			new string[]{"葵扇"},
			new string[]{"傑利蠑螈"},
			//
			new string[]{"", "1", "41","","1976/08/12", "榮泰、清泉、琳青、文凱、宗捷、哲榮\n秋宜、維穩、李偉、士杰", "","", "向下紮根 向上結果", ""},
			new string[]{"", "摩西", "", "米利暗、亞倫", "", "400", "雅歌","","", "西門(彼得)，安得烈，雅各，約翰，腓力，巴多羅買，多馬，稅吏馬太，亞勒腓的兒子雅各和達太，奮銳黨的西門，還有賣耶穌的加略人猶大", "成了!" },
			//
			//卡通
			new string[]{ "水見示","1","1","2" },
			//遊戲
			new string[]{"4","3"},
			//電影
			new string[]{"1", "忠孝介","1" },
			//時事
			new string[]{"3","4","1"},
			//美術
			new string[]{"2","3","1","1","3"},
			//神隱少女
			new string[]{ "賑早見琥珀主" }
		};
		string[] category = new string[]{
			"國文","數學","自然","地理","歷史","英文","生活",
			"體育","網球王子","蠟筆小新","鄉土","公民",
			"教會","聖經",
			"卡通","遊戲","電影","時事","美術","神隱少女"
		};
		string[] star_str = new string[]{
			"","★","★★","★★★","★★★★","★★★★★"
		};
		int[][] star = new int[][]{
			new int[]{3,2,1,3,2,1,1,1,2,3,2,4,4,2,1,2,3},
			new int[]{3,1,1,1,1,2,2,2,3,3},
			new int[]{1,3,1,1,2,2,3,3,3,2,3,2,4,5},
			new int[]{3,3,2,2,2,2,2,4,2},
			new int[]{2,2,1,5,3,2,1},
			new int[]{3,1,1,1,1,2,1,2,1,1,4},
			new int[]{2,1,2,1,1,2,2,2,3,2,2,2,3},
			//
			new int[]{3,2,2,2,2,1,2,2,3,2,4,4,2},
			new int[]{5},
			new int[]{4},
			new int[]{4},
			new int[]{5},
			//
			new int[]{2,1,1,2,2,3,2,2,1,2},
			new int[]{2,1,1,1,3,3,2,2,3,3,2},
			//
			new int[]{3,1,2,3},
			new int[]{2,1},
			new int[]{1,2,1},
			new int[]{2,2,1},
			new int[]{2,3,2,2,3},
			new int[]{5}
		};
		int restCategory;
		int[] question_index;
		int[] button_category;
		int[] button_index;
		int[] nowused;
		const int spacing = 40;
		public Form1()
		{
			InitializeComponent();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					buttons[i * 3 + j] = new Button();
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int w = (this.Width - spacing * 4) / 3;
			int h = (this.Height - spacing * 4) / 3;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					buttons[i * 3 + j].Left = spacing * (j + 1) + w * j;
					buttons[i * 3 + j].Top = spacing * (i + 1) + h * i;
					buttons[i * 3 + j].Width = w;
					buttons[i * 3 + j].Height = h;
					buttons[i * 3 + j].Font = new Font("微軟正黑體", 30);
					buttons[i * 3 + j].Click += Button_Click;
					Controls.Add(buttons[i * 3 + j]);
				}
			}
			setColor();
			label_question.Top = 10;
			label_question.Height = (this.Height - spacing * 4) / 3;
			label_option.Top = (this.Height - spacing * 4) / 3 + 80;
			label_option.Height = (this.Height - spacing * 4) / 2;
			label_option.Visible = false;
			label_question.Visible = false;
			label_option.Font = new Font("微軟正黑體", 30);
			label_question.Font = new Font("微軟正黑體", 30);
			nextButton.Visible = false;
			nextButton.Font = new Font("微軟正黑體", 30);
			label_answer.Left = label_option.Left + label_option.Width / 2;
			label_answer.Top = label_option.Top;
			label_answer.Width = label_option.Width / 2;
			label_answer.Height = label_option.Height;
			label_answer.Visible = false;
			label_answer.Font = new Font("微軟正黑體", 30);
			restCategory = question.GetLength(0);
			question_index = Enumerable.Repeat(-1, question.GetLength(0)).ToArray();
			button_category = Enumerable.Repeat(0, 9).ToArray();
			button_index = Enumerable.Repeat(0, 9).ToArray();
			//nowused = Enumerable.Repeat(-1, question.GetLength(0)).ToArray();
			refill(-1);
		}

		private void setColor()
		{
			foreach(Button b in buttons)
			{
				if (b.Enabled==false)
				{
					b.BackColor = DefaultBackColor;
				}
				else
				{
					b.BackColor = Color.FromArgb(100, r.Next(256), r.Next(256), r.Next(256));
				}
			}
			label_question.BackColor = Color.FromArgb(100, r.Next(256), r.Next(256), r.Next(256));
			label_answer.BackColor = Color.FromArgb(40, r.Next(256), r.Next(256), r.Next(256));
			label_option.BackColor = Color.FromArgb(100, r.Next(256), r.Next(256), r.Next(256));
			nextButton.BackColor = Color.FromArgb(60, r.Next(256), r.Next(256), r.Next(256));
		}

		private void refill(int press)
		{
			int cindex = 0;
			nowused = Enumerable.Repeat(-1, 9).ToArray();
			if (restCategory >= 9)
			{
				if (press < 0)
				{
					for (int i = 0; i < 9; i++)
					{
						if (nowused.Contains(cindex) || question_index[cindex] == answer[cindex].Length - 1)
						{
							cindex++;
							i--;
							continue;
						}
						else
						{
							button_category[i] = cindex;
							button_index[i] = ++question_index[cindex];
							buttons[i].Text = category[cindex] + "\n" + star_str[star[cindex][button_index[i]]];
							nowused[i] = cindex;
							if (star[cindex][button_index[i]] > 3)
							{
								buttons[i].Text = "魔王題\n" + buttons[i].Text;
							}
							cindex++;
						}
					}
				}
				else
				{
					buttons[press].Text = "";
					buttons[press].Enabled = false;
					if (question_index[button_category[press]] == answer[button_category[press]].Length - 1)
					{
						for(int i = 0; i < 9; i++)
						{
							nowused[i] = button_category[i];
						}
						for(int i = 0; i < question.Length; i++)
						{
							if (nowused.Contains(i) == false && question_index[i] != answer[i].Length - 1)
							{
								button_category[press] = i;
								button_index[press] = ++question_index[i];
								buttons[press].Text = category[i] + "\n" + star_str[star[i][button_index[press]]];
								buttons[press].Enabled = true;
								if (star[i][button_index[press]] > 3)
								{
									buttons[press].Text = "魔王題\n" + buttons[press].Text;
								}
								break;
							}
						}
					}
					else
					{
						button_index[press] = ++question_index[button_category[press]];
						buttons[press].Text = category[button_category[press]] + "\n" + star_str[star[button_category[press]][button_index[press]]];
						buttons[press].Enabled = true;
						if (star[button_category[press]][button_index[press]] > 3)
						{
							buttons[press].Text = "魔王題\n" + buttons[press].Text;
						}
					}
				}
			}
			else
			{
				if (press < 0)
				{
					for (int i = 0; i < 9; i++)
					{
						if (cindex == question.Length)
						{
							buttons[i].Text = "";
							buttons[i].Enabled = false;
						}
						else
						{
							if (question_index[cindex] != answer[cindex].Length - 1)
							{
								button_category[i] = cindex;
								button_index[i] = ++question_index[cindex];
								buttons[i].Text = category[cindex] + "\n" + star_str[star[cindex][button_index[i]]];
								if (star[cindex][button_index[i]] > 3)
								{
									buttons[press].Text = "魔王題\n" + buttons[press].Text;
								}
							}
							else
							{
								cindex++;
								i--;
								continue;
							}
						}
					}
				}
				else
				{
					buttons[press].Text = "";
					buttons[press].Enabled = false;
					if (question_index[button_category[press]] == answer[button_category[press]].Length - 1)
					{
						for (int i = 0; i < question.Length; i++)
						{
							if (question_index[i] != answer[i].Length - 1)
							{
								button_category[press] = i;
								button_index[press] = ++question_index[i];
								buttons[press].Enabled = true;
								buttons[press].Text = category[i] + "\n" + star_str[star[i][button_index[press]]];
								if (star[i][button_index[press]] > 3)
								{
									buttons[press].Text = "魔王題\n" + buttons[press].Text;
								}
								break;
							}
						}
					}
					else
					{
						button_index[press] = ++question_index[button_category[press]];
						buttons[press].Enabled = true;
						buttons[press].Text = category[button_category[press]] + "\n" + star_str[star[button_category[press]][button_index[press]]];
						if (star[button_category[press]][button_index[press]] > 3)
						{
							buttons[press].Text = "魔王題\n" + buttons[press].Text;
						}

					}
				}
			}
			setColor();
		}
		private void Button_Click(object sender, EventArgs e)
		{
			Button pressed = (Button)sender;
			press = -1;
			for (int i = 0; i < 9; i++)
			{
				if (pressed.Equals(buttons[i]))
				{
					press = i;
				}
				buttons[i].Visible = false;
			}
			if (question_index[button_category[press]] == question[button_category[press]].Length - 1)
			{
				restCategory--;
			}
			label_option.Visible = true;
			label_question.Visible = true;
			nextButton.Visible = true;
			nextButton.Text = "答案";
			label_answer.Text = "答案";
			label_answer.Visible = false;
			label_question.Text = question[button_category[press]][button_index[press]];
			label_option.Text = option[button_category[press]][button_index[press]];
			label_option.TextAlign = ContentAlignment.MiddleCenter;
			setColor();
		}

		private void nextButton_Click(object sender, EventArgs e)
		{
			if (nextButton.Text == "答案")
			{
				label_answer.Text = answer[button_category[press]][button_index[press]];
				label_answer.Visible = true;
				label_option.TextAlign = ContentAlignment.MiddleLeft;
				nextButton.Text = "返回";
			}
			else if (nextButton.Text == "返回")
			{
				for (int i = 0; i < 9; i++)
				{
					buttons[i].Visible = true;
				}
				/*for (int i = 0; i < question_index.Length; i++)
				{
					if (question_index[i] == question[button_category[i]].Length - 1)
					{
						restCategory--;
					}
				}*/
				buttons[press].Enabled = false;
				label_option.Visible = false;
				label_question.Visible = false;
				label_answer.Visible = false;
				nextButton.Visible = false;
				setColor();
				refill(press);
			}
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized)
			{
				int w = (this.Width - spacing * 4) / 3;
				int h = (this.Height - spacing * 4) / 3;
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						buttons[i * 3 + j].Left = spacing * (j + 1) + w * j;
						buttons[i * 3 + j].Top = spacing * (i + 1) + h * i;
						buttons[i * 3 + j].Width = w;
						buttons[i * 3 + j].Height = h;
					}
				}
				label_question.Top = 10;
				label_question.Height = (this.Height - spacing * 4) / 3;
				label_option.Top = (this.Height - spacing * 4) / 3 + 80;
				label_option.Height = (this.Height - spacing * 4) / 2;
				label_answer.Left = label_option.Left + label_option.Width / 2;
				label_answer.Top = label_option.Top;
				label_answer.Width = label_option.Width / 2;
				label_answer.Height = label_option.Height;
			}
		}
	}
}

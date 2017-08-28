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
			new string[]{"成語「病入膏肓」當中的膏指的是心臟，而肓指的是？","成語「直搗黃龍」中的「黃龍」指的是？","明月幾時有？把酒問青天。是誰的詩詞？", "「唐詩三百首」是由哪個朝代的人所編輯的？", "何者不是4大名著之一?", "成語『東施效顰』中的『顰』是指哪一個動作？", "『人生以服務為目的』這句話是哪個偉人說的？", "“悄悄地揮一揮手，不帶走一片雲彩”的是詩人：", "網路上流行的『囧』字，正確的意思是什麼？", "用來形容色彩鮮豔奪目的五彩繽紛，當中的『五彩』原本是指？", "「詩豪」意指何人?","六畜興旺中的“六畜”是指哪六種?","請問四書五經中的四書為何?" },
			new string[]{ "哥哥6歲時，妹妹的年齡是他的一半，請問哥哥50歲時妹妹幾歲？", "所謂的一刻鐘是指？", "六角柱比六角錐多幾個面？", "在數學上，幾個邊以上的平面圖形，都叫做『多邊形』？", "1KG的鐵塊跟1KG的羽毛何者比較重?", "自來水公司以『度』來計算水量，１度等於多少立方公尺的水？", "平行四邊形的每一個邊都可以叫做？", "在除法計算中，餘數一定大於除數？", "單車環島一週約１３０ ０公里 ，若每天騎６小時，每小時騎 ８公里 ，的幾天可以完成環島？", "有20隻雞跟兔子，只知道他們有54隻腳，請問雞跟兔各有幾隻?" },
			new string[]{ "下雨天時總是先看到閃電才聽到雷聲，那是因為？", "在月球上十公斤重的人，回到地球上會是幾公斤？", "大肚魚是用什麼方式繁殖的？", "彈塗魚在陸上活動時，是用什麼在呼吸？", "氣象局在預測２４小時累積雨量時到達多少毫米，就會發布『大豪雨特報』？", "ㄧ天當中的哪個時候，公園的空氣『含氧量』最高？", "正常人體體細胞有多少條染色體？", "小蜜蜂跳著８字舞是想告訴同伴，香甜的蜂蜜就在？", "蜘蛛會吐絲結網捕捉獵物，那他所吐的絲其實是？", "水蠆（ㄔㄞˋ）是哪一種昆蟲的小時候？" },
			new string[]{ "台灣最小的市是「台北永和」，請問最小的鄉鎮是哪裡？", "請以北至南依序排列台灣名山？", "台語的『胖』指的是麵包，這個發音最早原自？", "小明一家人想去洗世界上少有的海底溫泉，她們應該去哪裡？", "台灣諺語頂港有名聲，下港有出名請問頂港、下港是用什麼來分界？", "稱為『玫瑰之國』的國家為何者?", "世界上地勢最低的國家是：","請問石灰岩地形又稱為什麼地形?" },
			new string[]{ "請問2次世界大戰中的軸心國成員為哪3國?", "請問一日三餐是從何時開始?", "“五十步笑百步”出自：","請問八國聯軍為哪八國?" },
			new string[]{ "捷運的英文縮寫是MRT，那請問捷運的英文全名是什麼？", "白雪公主叫Snow White，請問白馬王子叫什麼？", "The sun rises___the east. 空格處應填入？", "Sheep feed ___ grass.中間應填入？", "Ｋｅｔｃｈｕｐ的意思是什麼？", "海綿寶寶最愛的寵物是誰？", "媽咪是許多人對媽媽的暱稱，以下何者是美式媽咪的正確拼字？", "以下哪個選項屬於人體『器官』？", "被踩到腳時，中文我們會說『哎喲』，英文該怎麼說？", "以下那一個數字最大？" },
			new string[]{ "在速限５ ０公里 以下路段，發生汽車車禍，應將三角警告牌放在車輛後方幾公尺？", "迪士尼經典卡通人物米老鼠養的寵物叫什麼名字？", "人人愛用的FACEBOOK請問成立於何時?", "『紫外線指數』的英文縮寫是什麼？", "以下哪些作品不是宮崎駿的作品？", "教育部至2010年開始訂有「祖父母節」，請問是哪一天?", "人民的保母－警察，他身上配戴的階級胸章位在？", "ＣＰＲ練習對象『甦醒安妮』，她的名稱由來是因為發明者？", "如果把一個成人的全部血管連接起來，其長度接近多少公里？", "飛沫傳染是一種直接傳染途徑，以下那種疾病不是經由飛沫傳染？" },
			//
			new string[]{ "排球1895年始於那個國家？", "請問NBA籃球規則中規定個人犯規幾次即畢業離場？", "職籃規則中規定，團隊犯規每節超過幾次則要罰球兩次？", "桌球比賽中發球觸網球有過則?", "排球比賽中隊伍上有位身穿不同顏色衣服的球員為何?", "請問棒球比賽中游擊手代號為何?", "請問飛盤比賽中一隊正規出場先發有幾人", "躲避球規則中球員接到球後必須幾秒內出手?", "女排的球網有多高？", "跑步比賽被喻為世界最快的男人請問是何者?", "請問奧運五環為哪五色", "請問2004年奧運在哪裡舉辦?" },
			new string[]{ "請問網球王子中的無我堂奧的三道門是哪三道?" },
			new string[]{ "請問野原廣志所待的公司為何?" },
			new string[]{ "請問『扇子』的台語如何念?" },
			new string[]{ "來自美國的哪個政治術語，指以不公平的選區劃分方法操縱選舉，致使投票結果有利於某方?" },
			//
			new string[]{ "請問教會有哪幾個牧區?", "這次活動總召為下列何者?", "請問富強教會現在幾歲?", "請問富強教會地址?", "請問富強教會何時設立?", "請列舉教會5位現任執事?", "教會的電話是?", "聖歌隊的譜務室的位置?", "提摩太牧區年度目標?", "請說出提摩太牧區所有的小組名" },
			new string[]{ "請列舉4封保羅寫的書信名稱", "聖經的創世紀是神感動誰寫的?", "請說出一對舊約中雙胞胎名字", "摩西的姐姐和哥哥叫什麼名字?", "請說出舊約中的4位先知名字", "舊約和新約之間隔了大約幾百年?", "舊約的傳道書後面是哪一卷書?", "請列舉4個聖經中提到的地名", "請列舉舊約中4個國王的名字", "請列舉耶穌門徒的名字，舉一個得一分，錯兩個以上開始倒扣", "耶穌在十字架上斷氣前說的最後一句話是?" }
			
		};
		string[][] option = new string[][]{
			new string[]{ "〈1〉肺\n〈2〉肝\n〈3〉橫隔膜", "〈1〉一個土塵\n〈2〉一個車營\n〈3〉一個都城", "1李白\n2白居易\n3蘇東坡\n4杜甫", "〈1〉唐朝\n〈2〉宋朝\n〈3〉清朝", "1紅樓夢\n2三國演義\n3西遊記\n4水武傳","", "（１）孫中山\n（２）蔣中正\n（３）胡適", "1徐志摩\n2舒婷\n3席慕容\n4北島", "（１）光輝明亮\n（２）出糗尷尬\n（３）風和日麗","（１）紅、黃、白、黑、青\n（２）藍、青、黃、紅、黑\n（３）黃、紅、紫、青、白", "1王維\n2王昌齡\n3李賀\n4劉禹錫","","" },
			new string[]{ "","1. 15分鐘\n2. 30分鐘\n3.一小時","","", "（１）鐵塊\n（２）羽毛\n（３）一樣重","", "（１）底\n（２）高\n（３）寬","","","" },
			new string[]{ "〈1〉閃電是雷的前導預兆\n〈2〉光速比音速快\n〈3〉視覺較聽覺敏銳","", "（１）胎生\n（２）卵生\n（３）卵胎生","", "（１）200毫米 以上\n（２）300毫米 以上\n（３）350毫米 以上", "（１）清晨\n（２）中午\n（３）傍晚", "1.36條\n2.48條\n3.46條\n4.38條", "（１）眼前不遠處\n（２）１００公尺內\n（３）１００公尺外", "（１）腹部的黏液\n（２）嘴裡的口水\n（３）前肢紡絲器黏液", "（１）蜻蜓\n（２）蚊子\n（３）蒼蠅" },
			new string[]{ "1.苗栗 公館鄉\n2.雲林 虎尾鎮\n3.宜蘭 羅東鎮", "〈1〉合歡山\n〈2〉八卦山\n〈3〉鐵山\n〈4〉半屏山", "（１）日語\n（２）西班牙語\n（３）葡萄牙語", "（１）澎湖\n（２）蘭嶼\n（３）綠島", "（１）大安溪\n（２）大甲溪\n（３）濁水溪", "1.奈及利亞\n2.保加利亞\n3.匈牙利", "1.芬蘭\n2.冰島\n3.挪威\n4.荷蘭","" },
			new string[]{"", "1.秦朝\n2.唐朝\n3.宋朝\n4.明朝", "1三國志\n2孟子\n3晏子春秋\n4三國演義","" },
			new string[]{"","", "〈1〉on\n〈2〉fron\n〈3〉in", "〈1〉by\n〈2〉in\n〈3〉on", "（１）番茄醬\n（２）投手\n（３）帆船", "（１）Ｓｎａｉｌ\n（２）Ｏｗｌ\n（３）Ｊｅｌｌｙｆｉｓｈ", "（１）ｍａｍｍｙ\n（２）ｍｕｍｍｙ\n（３）ｍｏｍｍｙ", "（１）ｔｈｉｃｋ\n（２）ｃｈｉｃｋ\n（３）ｃｈｉｎ", "（１）Ｗｈｅｅ！\n（２）Ｏｏｐｓ！\n（３）Ｏｕｃｈ！", "（１）ｍｉｌｌｉｏｎ\n（２）ｔｒｉｌｌｉｏｎ\n（３）ｂｉｌｌｉｏｎ" },
			new string[]{ "（１）１０公尺\n（２）２０公尺\n（３）３０公尺","", "1.2004年2月\n2.2004年3月\n3.2004年4月\n4.2005年3月","", "1千與千尋的神隱\n2龍貓\n3紅髮少女安妮\n4天空的守護神","", "（１）右邊口袋上方\n（２）左邊口袋上方\n（３）左領口", "（１）自己叫安妮\n（２）太太叫安妮\n（３）女兒叫安妮", "1.10\n2.1000\n3.10000\n4.10萬", "（１）腮腺炎\n（２）禽流感\n（３）鼠疫" },
			//
			new string[]{ "1日本\n2英國\n3荷蘭\n4美國", "1.三次\n2.四次\n3.五次\n4.六次", "1.四次\n2.五次\n3.六次\n4.七次", "1.對方得分\n2.重新發球\n3.繼續比賽","", "1.DH\n2.SS\n3.3B\n4.P", "1.5人\n2.6人\n3.7人\n4.8人", "1.3秒\n2.4秒\n3.5秒\n4.6秒", "1.2.15m\n2.2.34m\n3.2.24m\n4.2.25m","","","" },
			new string[]{""},
			new string[]{""},
			new string[]{""},
			new string[]{""},
			//
			new string[]{"", "1.詠丞\n2.智祈\n3.岳錡哥\n4.郁郁姐","","","","","","","","" },
			new string[]{"","","","","","","","","","",""}
		};
		string[][] answer = new string[][]{
			new string[]{ "3 橫隔膜", "3 一個都城", "3", "3 清朝", "1", "皺眉", "1 孫中山", "Ｘ1", "（１）\n光輝明亮","1\n紅、黃、白、黑、青", "2", "豬、牛、馬、羊、狗、雞", "論語 孟子 大學 中庸"},
			new string[]{ "47歲", "1. 15分鐘", "1個面", "３個", "3 一樣重", "1 立方公尺", "1 底", "Ｘ", "２８天", "雞13 兔子7"},
			new string[]{ "2 光速比音速還快", "60公斤", "3 卵胎生", "皮膚", "２００毫米 以上", "3 傍晚", "3", "3 \n１００公尺外","1\n腹部的黏液","（１）蜻蜓"},
			new string[]{ "1. 宜蘭 羅東鎮", "4 2 1 3", "3\n葡萄牙語", "3 綠島", "3 濁水溪", "2", "4", "喀斯特地形"},
			new string[]{ "德國.日本.義大利", "3", "2", "俄.德.法.美.日.奧.義.英"},
			new string[]{ "Mass Rapid Transit", "Prince Charming", "〈3〉in", " 〈3〉on", "１）番茄醬", "１）Ｓｎａｉｌ", "３）ｍｏｍｍｙ", "３）ｃｈｉｎ下巴", "3）Ｏｕｃｈ！", "２）ｔｒｉｌｌｉｏｎ"},
			new string[]{ "（３）３０公尺", "布魯托", "1", "ＵＶＩ", "4", "8月第四個周日", "（１）\n右邊口袋上方", "（３）女兒叫安妮", "4", "（２）禽流感"},
			//
			new string[]{"4","4","2","2", "自由球員", "2","3","3","3", "USAINT BOLT", "黑黃紅藍綠", "希臘雅典"},
			new string[]{"百鍊自得.才華洋溢.天衣無縫"},
			new string[]{"雙葉商事"},
			new string[]{"葵扇"},
			new string[]{"傑利蠑螈"},
			//
			new string[]{"", "1", "","","","榮泰.清泉.琳青.文凱.宗捷.哲榮\n.秋宜.維穩.李偉.士杰.","","", "向下紮根 向上結果", ""},
			new string[]{"", "摩西", "", "米利暗、亞倫", "", "400", "雅歌","","", "西門(彼得)，安得烈，雅各，約翰，腓力，巴多羅買，多馬，稅吏馬太，亞勒腓的兒子雅各和達太，奮銳黨的西門，還有賣耶穌的加略人猶大", "成了!" }
		};
		string[] category = new string[]{
			"國文","數學","自然","地理","歷史","英文","生活",
			"體育","網球王子","蠟筆小新","鄉土","公民",
			"教會","聖經"
		};
		string[] star_str = new string[]{
			"","★","★★","★★★","★★★★","★★★★★"
		};
		int[][] star = new int[][]{
			new int[]{3,2,1,3,2,1,1,1,2,3,2,4,4},
			new int[]{3,1,1,1,1,2,2,2,3,3},
			new int[]{1,3,1,1,2,2,3,3,3,2},
			new int[]{3,3,2,2,2,2,2,4},
			new int[]{2,2,1,5},
			new int[]{3,1,1,1,1,2,1,2,1,1},
			new int[]{2,1,2,1,1,2,2,2,3,2},
			//
			new int[]{3,2,2,2,2,1,2,2,3,2,4,4},
			new int[]{5},
			new int[]{4},
			new int[]{4},
			new int[]{5},
			//
			new int[]{2,1,1,2,2,3,2,2,1,2},
			new int[]{2,1,1,1,3,3,2,2,3,3,2}
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
								break;
							}
						}
					}
					else
					{
						button_index[press] = ++question_index[button_category[press]];
						buttons[press].Text = category[button_category[press]] + "\n" + star_str[star[button_category[press]][button_index[press]]];
						buttons[press].Enabled = true;
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
								break;
							}
						}
					}
					else
					{
						button_index[press] = ++question_index[button_category[press]];
						buttons[press].Enabled = true;
						buttons[press].Text = category[button_category[press]] + "\n" + star_str[star[button_category[press]][button_index[press]]];

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

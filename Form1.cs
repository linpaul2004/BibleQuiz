using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BibleQuiz
{
	public partial class Form1 : Form
	{
		Button[] buttons = new Button[9];
		int press;
		Random r = new Random();
		string[][] question = new string[][]{
			new string[]{"祭司長和全公會尋找見證控告耶穌，結果如何?"},
			new string[]{"彼得發現自己真的三次不認主後，如何反應?","祭司為什麼讓神生氣？(瑪拉基書1:6~8)"},
			new string[]{ "他必使_______的心轉向_______，_______的心轉向_______。", "唯有_______到底的必人得救", "耶穌說:凡勞苦單重擔的人可以到我這裡來，我就使你們得_____"},
			new string[]{"耶穌所行的第一個神蹟為何?"},
			new string[]{"耶穌派遣門徒時，要門徒帶什麼就好之外其他都不要帶?"},
			new string[]{"馬可福音4章中，耶穌平靜了海上的風浪，從他的傳道行程來看這個海是？"},
			new string[]{"下列哪一個動物和耶穌比喻財主進天國有關？","行詭詐的在群中有____，他許願卻用有殘疾的獻給主，這人是可咒詛的。","請問撒種的比喻中，種子代表什麼？","神的國好像一粒麥子，落在土裡死了，就長起來，長出大枝來，天上的飛鳥可以居宿在它的蔭下。"},
			new string[]{"瑪拉基書中耶和華要為以色列百姓斥責什麼？"},
			new string[]{"當博士們循著星星找到剛出生的耶穌的時候，拿了什麼當禮物獻給耶穌？"},
			//
			new string[]{"耶穌從殿裏出來的時候，有一個門徒對他說：「夫子，請看，這是何等的石頭！」這石頭是指什麼?" },
			new string[]{ "人子再來的日子，誰知道?" },
			new string[]{ "逾越節又叫什麼節?","每逢什麼節期，巡撫會照眾人要求，釋放一個囚犯?" },
			new string[]{ "耶穌如何評論澆香膏的女子?", "法利賽人因為在安息日醫病，出去和什麼人商議要消滅耶穌?", "彼拉多問耶穌是否是猶太人的王，耶穌回答?","『以羅伊，以羅伊，拉馬撒巴各大尼』的意思是？","耶穌受了約翰的洗，天上有聲音說什麼？" },
			new string[]{ "耶穌沒有說過哪一個比喻？" },
			new string[]{ "馬可福音是用什麼語言寫的？", "耶穌使葉魯的女兒復活，對他說『大利大，古來！』，是什麼意思？" },
			new string[]{ "耶穌設立聖餐禮時，是吃哪一餐時?" },
			//
			new string[]{ "瑪拉基書4章五-六節說到「在上主大而可畏的日子來到以前，我要差派先知_____到你們那裏。他要使父親和兒女再度和好，免得我來滅這地。」請問是何位先知?", "瑪拉基的意思為何?", "耶穌對什麼人說我要叫你們得人如魚?", "哪一個人沒有譏笑耶穌?", "耶穌帶著彼得、雅各、約翰上了一座山，在他們面前變了形象，耶穌身旁有兩人與他說話請問是哪兩位？", "哪兩位門徒請耶穌坐在榮耀寶座上時，讓他們一個坐左邊，一個坐右邊？", "耶穌帶了哪三位門徒一同去客西馬尼園禱告？", "第一位實行十一奉獻的聖經人物是", "請列舉12使徒中的六位(馬可3:14~19)", "瑪拉基書中提到，神差派祂的使者在前面預備道路，在馬可福音中的誰身上應驗？", "是哪個門徒在山上見到以利亞和摩西顯現，想和耶穌一起在那裡搭棚居住？", "耶穌說，什麼樣的人才能承受神的國？", "當耶穌上山禱告，在門徒面前變像，彼得對耶穌說：「拉比（就是夫子），我們在這裡真好！可以搭三座棚，一座為你，一座為______，一座為______。」", "在七日的第一日清早，耶穌復活了，就先向____________顯現。", "以東人的祖先____與以色列人的祖先____是什麼關係？", "你們廢棄我與______所立的約。" },
			new string[]{"在你們中間，誰願為首，就必做眾人的?"},
			new string[]{ "馬可福音寫作對象為？" },
			new string[]{ "瑪拉基的名字是『我的救贖』的意思" },
			new string[]{ "耶穌說：誰願為首，就必做________?", "耶穌被釘十字架時，在他左右一同被釘十字架的是什麼身分? " },
			new string[]{ "耶穌到客西馬尼園禱告時，帶了哪三位門徒?" },
			//
			new string[]{ "下列何者在瑪拉基書中不曾提到?" },
			new string[]{ "馬可傳道的目的以『因信稱義』為基礎。", "詩篇總共有幾篇?", "馬可福音最後一章最後一節的最後兩個字是什麼?" },
			new string[]{ "上帝說以色列百姓不敬畏他的名，是指何事？" },
			new string[]{ "耶穌如何潔淨長大痲瘋的人?" },
			new string[]{ "耶穌在曠野幾天，受撒旦的試探?", "耶穌總共傳道幾年?" },
			new string[]{ "耶穌拿著五餅二魚祝謝後分給五千人吃，收拾的零碎裝了幾籃子？", "耶穌拿著七塊餅祝謝後分給四千人吃，收拾的零碎裝了幾籃子？", "耶穌說彼得在雞叫以前要幾次不認耶穌?" },
			new string[]{ "除了誰以外，再沒有良善的?" },
			new string[]{ "猶大去見祭司長，要將耶穌交給他們，他們如何反應?" },
			//
			new string[]{ "耶穌在客西馬尼園禱告什麼?" },
			new string[]{ "何者不是瑪拉基書中傳遞的消息？" },
			new string[]{ "找耶穌治病的癱子是用什麼方法見到耶穌的？" },
			new string[]{ "耶穌說他來乃是要召什麼人？" },
			new string[]{ "法利賽人想要殺耶穌，因為耶穌在安息日做了什麼事？" }
		};
		string[][] option = new string[][]{
			new string[]{"A.找到三個\nB.找到一個\nC.找到兩個\nD.找不到"},
			new string[]{"A.發瘋\nB.傳福音\nC.哭泣\nD.仰天長嘯","A.因為拜偶像\nB.祭司們在聖殿飲酒作樂\nC.祭司獻有殘疾的祭物(不尊重神)"},
			new string[]{"","A.相信\nB.奮鬥\nC.守望\nD.忍耐","A.安寧\nB.安慰\nC.安麗\nD.安息"},
			new string[]{"A.五餅二魚\nB.迦拿婚禮水變為酒\nC.水面上行走\nD.醫治拉撒路"},
			new string[]{"A.幾枚硬幣\nB.木杖\nC.食物\nD.旅行包包"},
			new string[]{"A.加利利湖\nB.地中海\nC.死海\nD.台灣海峽"},
			new string[]{"A.狗\nB.螞蟻\nC.鴿子\nD.駱駝","A.公羊\nB.公雞\nC.母牛\nD.駱駝","A.信心\nB.得救的人\nC.神的道\nD.聖靈",""},
			new string[]{"A.米蟲\nB.肥蟲\nC.蝗蟲\nD.毛毛蟲"},
			new string[]{"A.粽子、艾草、香包\nB.黃金、乳香、沒藥\nC.香膏、黃金、金粉\nD.月餅、玉兔、嫦娥"},
			//
			new string[]{ "A.死腦筋\nB.聖殿\nC.大理石\nD.道路" },
			new string[]{ "A.傳道\nB.天使\nC.神\nD.子" },
			new string[]{ "A.住棚節\nB.除酵節\nC.端午節\nD.五旬節", "A.住棚節\nB.清明節\nC.逾越節\nD.五旬節" },
			new string[]{ "A.不夠高級\nB.枉費香膏\nC.是一件美事\nD.不予評論", "A.希律黨人\nB.文士和祭司\nC.奮銳黨\nD.愛色尼人", "A.你猜猜看\nB.你說的是\nC.哪有可能\nD.真的假不了、假的真不了","","A.父啊，赦免他們\nB.你們回轉向我，我就回轉向你們\nC.神的國近了\nD.你是我的愛子，我喜悅你" },
			new string[]{ "A.芥菜種的比喻\nB.沙崙玫瑰的比喻\nC.葡萄園的比喻" },
			new string[]{ "A.希伯來文\nB.希臘文\nC.亞蘭文\nD.義大利文","A.沒有意思，就是個復活咒語\nB.閨女，我吩咐你起來\nC.不要怕，只要信\nD.女兒，你的信救了你" },
			new string[]{ "A.晚餐\nB.中餐\nC.消夜\nD.下午茶" },
			//
			new string[]{ "A.以西結\nB.以利亞\nC.以賽亞\nD.以斯帖", "A.神的力量\nB.神的僕人\nC.神的使者\nD.安慰者", "A.彼得和猶大\nB.雅各和約翰\nC.西門和安德烈\nD.馬可和馬太", "A.祭司長\nB.路過的人\nC.強盜\nD.古利奈人西門", "A.以賽亞、但以理\nB.摩西、以利亞\nC.約伯、耶利米\nD.大衛、以西結", "A.彼得、雅各\nB.安德烈、腓力\nC.雅各、約翰\nD.達太、西門", "A.雅各、約翰、達太\nB.安德烈、腓力、西門\nC.彼得、雅各、約翰\nD.馬太、馬可、多馬", "A.以撒\nB.保羅\nC.雅各\nD.亞伯拉罕", "", "A.施洗約翰\nB.以利亞\nC.以利沙\nD.保羅", "A.彼得\nB.約翰\nC.馬可","", "A.摩西、亞伯拉罕\nB.施洗約翰、以賽亞\nC.摩西、以利亞\nD.施洗約翰、聖母馬利亞", "A.彼拉多\nB.希律王\nC.彼得\nD.抹大拉的馬利亞", "A.歌利亞、大衛－敵人\nB.以掃、雅各－兄弟\nC.以撒、雅各－父子\nD.約伯、約瑟－沒關係", "A.雅各\nB.亞伯拉罕\nC.摩西\nD.利未" },
			new string[]{ "A.老師\nB.僕人\nC.顧問\nD.主人" },
			new string[]{ "A.耶路撒冷的猶太人\nB.馬可教會的信徒\nC.外邦的基督徒\nD.加利利的門徒" },
			new string[]{""},
			new string[]{ "A.僕人\nB.主人\nC.領袖\nD.好人", "A.王子\nB.強盜\nC.法利賽人\nD.稅吏" },
			new string[]{""},
			//
			new string[]{ "A.十一奉獻\nB.懲戒祭司\nC.末日審判\nD.選民更新" },
			new string[]{"","", "A.平安\nB.感謝\nC.啊哈\nD.阿們" },
			new string[]{ "A.不十一奉獻\nB.欺負妻子\nC.喜愛享受\nD.獻祭隨便" },
			new string[]{ "A.西藥\nB.唾液\nC.泥土\nD.用手摸他" },
			new string[]{ "A.三十天\nB.四十天\nC.二十天\nD.五十天", "A.1年\nB.2年\nC.3年\nD.4年" },
			new string[]{ "A.7\nB.9\nC.6\nD.12", "A.5\nB.7\nC.3\nD.10", "A.(8X4+10)÷6\nB.(52÷2+124)÷(25X2)\nC.3X(3³+63)" },
			new string[]{ "A.少年財主\nB.小孩\nC.神\nD.法利賽人" },
			new string[]{ "A.質疑\nB.要談判\nC.嘲笑\nD.歡喜" },
			//
			new string[]{ "A.從主的意思\nB.與神爭辯\nC.討論善後\nD.審判世人" },
			new string[]{ "A.表明神對以色列人的立約之愛\nB.責備以色列對上帝的不忠心\nC.提醒以色列人要謙卑，\n不可彼此批評論斷\nD.上帝要潔淨祭司，審判百姓" },
			new string[]{ "A.四個朋友把他抬到耶穌面前\nB.四個朋友破門而入\nC.四個朋友把他從屋頂垂下去\nD.四個朋友把耶穌抬到他面前" },
			new string[]{ "A.義人\nB.罪人\nC.以色列人\nD.失魂落魄的人" },
			new string[]{ "A.治病\nB.趕鬼\nC.在聖殿吃東西\nD.問法利賽人問題" }
		};
		string[][] answer = new string[][]{
			new string[]{"D"},
			new string[]{"D","C"},
			new string[]{"兒女 父親 父親 兒女","D","D"},
			new string[]{"B"},
			new string[]{"B"},
			new string[]{"A"},
			new string[]{"D","A","C","(X)[芥菜種]"},
			new string[]{"C"},
			new string[]{"B"},
			//
			new string[]{"B"},
			new string[]{"C"},
			new string[]{"B","C"},
			new string[]{"C","A","B", "我的神！我的神！你為何離棄我？","D" },
			new string[]{"B"},
			new string[]{"B","B"},
			new string[]{"A"},
			//
			new string[]{"B","C","C","D","B","C","C","D", "西門彼得、安得烈、西庇太之子雅各、雅各的兄弟約翰、腓力、巴多羅買、多馬、馬太、亞勒腓之子雅各、達太、奮銳黨的西門、加略人猶大","A","B","小孩","C","D","B","D" },
			new string[]{"B"},
			new string[]{"C"},
			new string[]{"X"},
			new string[]{"A","B"},
			new string[]{ "彼得、雅各、約翰" },
			//
			new string[]{"D"},
			new string[]{"X","150篇","D"},
			new string[]{"D"},
			new string[]{"D"},
			new string[]{"B","C"},
			new string[]{"D","B","B"},
			new string[]{"C"},
			new string[]{"D"},
			//
			new string[]{"A"},
			new string[]{"C"},
			new string[]{"C"},
			new string[]{"B"},
			new string[]{"A"}
		};
		string[] category = new string[]{
			"審判","情緒","金句","歷史","旅行","地理","動植物","昆蟲","獻禮",
			//
			"建築","時間","節期","會話","比喻","語文","飲食",
			//
			"人物","領袖","對象","姓名","角色","門徒",
			//
			"知識","常識","求知","醫療","數字","數學","品行","態度",
			//
			"思想","消息","想盡辦法","異象","事蹟"
		};
		string[] star_str = new string[]{
			"","★","★★","★★★"
		};
		int[][] star = new int[][]{
			new int[]{1},
			new int[]{1,2},
			new int[]{2,1,1},
			new int[]{1},
			new int[]{1},
			new int[]{2},
			new int[]{1,2,1,2},
			new int[]{1},
			new int[]{1},
			//
			new int[]{1},
			new int[]{1},
			new int[]{2,2},
			new int[]{1,1,1,2,1},
			new int[]{1},
			new int[]{2,2},
			new int[]{1},
			//
			new int[]{2,2,1,2,1,2,1,2,3,1,1,1,2,2,3,3},
			new int[]{1},
			new int[]{1},
			new int[]{2},
			new int[]{1,1},
			new int[]{1},
			//
			new int[]{2},
			new int[]{1,3,1},
			new int[]{3},
			new int[]{2},
			new int[]{2,1},
			new int[]{1,1,3},
			new int[]{1},
			new int[]{1},
			//
			new int[]{2},
			new int[]{2},
			new int[]{1},
			new int[]{1},
			new int[]{2}
		};
		int restCategory;
		int[] question_index;
		int[] button_category;
		int[] button_index;
		int[] nowused;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int spacing = 40;
			int w = (this.Width - spacing * 4) / 3;
			int h = (this.Height - spacing * 4) / 3;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					buttons[i * 3 + j] = new Button();
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
			refill();
		}

		private void setColor()
		{
			foreach(Button b in buttons)
			{
				Console.WriteLine(b.Enabled);
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

		private void refill()
		{
			int cindex = 0;
			nowused = Enumerable.Repeat(-1, 9).ToArray();
			for (int i = 0; i < 9; i++)
			{
				buttons[i].Enabled = true;
			}
			if (restCategory >= 9)
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
				label_answer.Text = "答案：\n" + answer[button_category[press]][button_index[press]];
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
				for (int i = 0; i < 9; i++)
				{
					if (buttons[i].Enabled == true)
					{
						return;
					}
				}
				refill();
			}
		}
	}
}

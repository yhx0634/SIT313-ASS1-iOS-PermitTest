using Foundation;
using System;
using UIKit;
using System.Collections.Generic;


namespace PermitTest
{
    public partial class TestViewController : UIViewController
    {
		public int language;
		public int type;
        private int[] quesNumber = new int[10];
		private int count = 0;
		private int answerCount = 0;
		private int QuestionNo = 0;
		private string correctAnswer { get; set; }
		public List<int> WrongCount { get; set; }
		public List<int> RightCount { get; set; }


		public TestViewController (IntPtr handle) : base (handle)
        {
			WrongCount = new List<int>();
			RightCount = new List<int>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			topView.BackgroundColor = UIColor.FromRGB(74, 144, 226);

			btnBack.TouchUpInside += (object sender, EventArgs e) =>
			{
				//ViewController homwview = this.Storyboard.InstantiateViewController("homeView") as ViewController;
				//this.NavigationController.PushViewController(homwview, true);

				NavigationController.PopToRootViewController(true);
			};


			this.NavigationItem.SetLeftBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, args) =>
				{
					NavigationController.PopToRootViewController(true);
				})
			, true);

			if (type == 2)
			{
				getReview();

				btnA.TouchUpInside += (sender, e) =>
				{
					showAnswer(1, QuestionNo);
				};
				btnB.TouchUpInside += (sender, e) =>
				{
					showAnswer(2, QuestionNo);
				};
				btnC.TouchUpInside += (sender, e) =>
				{
					showAnswer(3, QuestionNo);
				};
			}

			if (type == 0)
			{
				btnPreview.Hidden = true;
				btnNext.Hidden = true;
				random();
				btnA.TouchUpInside += (sender, e) =>
				{
					nextQues(1, QuestionNo);
					if (answerCount >= 10)
					{
						ResultViewController ResultController = this.Storyboard.InstantiateViewController("resultController") as ResultViewController;
						ResultController.WrongAnswer = WrongCount;
						ResultController.RightAnswer = RightCount;
						ResultController.type = 0;
						ResultController.language = language;
						this.NavigationController.PushViewController(ResultController, true);
					}
					else
						switchQues();
				};
				btnB.TouchUpInside += (sender, e) =>
				{
					nextQues(2, QuestionNo);
					if (answerCount >= 10)
					{
						ResultViewController ResultController = this.Storyboard.InstantiateViewController("resultController") as ResultViewController;
						ResultController.WrongAnswer = WrongCount;
						ResultController.RightAnswer = RightCount;
						ResultController.type = 0;
						ResultController.language = language;
						this.NavigationController.PushViewController(ResultController, true);
					}
					else
						switchQues();
				};
				btnC.TouchUpInside += (sender, e) =>
				{
					nextQues(3, QuestionNo);

					if (answerCount >= 10)
					{
						ResultViewController ResultController = this.Storyboard.InstantiateViewController("resultController") as ResultViewController;
						ResultController.WrongAnswer = WrongCount;
						ResultController.RightAnswer = RightCount;
						ResultController.type = 0;
						ResultController.language = language;
						this.NavigationController.PushViewController(ResultController, true);
					}
					else
						switchQues();
				};
			}

			if (type == 1)
			{
				getQuesNo();

				btnA.TouchUpInside += (sender, e) =>
				{
					showAnswer(1, QuestionNo);
				};
				btnB.TouchUpInside += (sender, e) =>
				{
					showAnswer(2, QuestionNo);
				};
				btnC.TouchUpInside += (sender, e) =>
				{
					showAnswer(3, QuestionNo);
				};

			}

			switchQues();

			btnNext.TouchUpInside += (object sender, EventArgs e) =>
			{
				if (answerCount == quesNumber.Length-1)
					btnNext.SetTitle("Done", UIControlState.Normal);

				if(type == 2)
					if (answerCount < reviewCount)
					{
						switchQues();
						btnA.BackgroundColor = UIColor.White;
						btnB.BackgroundColor = UIColor.White;
						btnC.BackgroundColor = UIColor.White;
					if(answerCount == reviewCount)
						btnNext.SetTitle("Done", UIControlState.Normal);
					}
					else
					{
						
						NavigationController.PopToRootViewController(true);
					}
				if(type != 2)	
					if (answerCount < 10)
					{
						switchQues();
						btnA.BackgroundColor = UIColor.White;
						btnB.BackgroundColor = UIColor.White;
						btnC.BackgroundColor = UIColor.White;
					}
					else
					{
						Console.WriteLine(WrongCount);
						ResultViewController ResultController = this.Storyboard.InstantiateViewController("resultController") as ResultViewController;
						ResultController.WrongAnswer = WrongCount;
						ResultController.RightAnswer = RightCount;
						ResultController.type = 1;
					ResultController.language = language;
						this.NavigationController.PushViewController(ResultController, true);
					}

			};

			btnPreview.TouchUpInside += (sender, e) =>
			{
				btnA.Enabled = true;
				btnB.Enabled = true;
				btnC.Enabled = true;

				btnA.BackgroundColor = UIColor.White;
				btnB.BackgroundColor = UIColor.White;
				btnC.BackgroundColor = UIColor.White;

				if (answerCount > 0)
					switchPrewQues();
				if (answerCount == 1 && type == 1)
					btnPreview.Hidden = true;
				

			};
		}

        

        public class Questions
        {
            public string question { get; set; }
            public string answera { get; set; }
            public string answerb { get; set; }
            public string answerc { get; set; }
            public string answerd { get; set; }
            public int answer { get; set; }
        }

		public void getQuesNo()
		{
			for (int i = 0; i < quesNumber.Length;)
			{
				quesNumber[i] = i+1;
				i++;
			}
		}

		private int reviewCount = 0;
		public void getReview()
		{
			foreach (int w in WrongCount)
			{
				Console.WriteLine(w);
				quesNumber[reviewCount] = w;
				Console.WriteLine(quesNumber[reviewCount]);
				reviewCount++;

			}
		}

		public void random()
		{
			
			Random r = new Random();
			for (int i = 0; i < quesNumber.Length;)
			{
				var temp = r.Next(1, 11);
				if (!indexOf(temp))
				{ 
					quesNumber[i] = temp;
					i++;
					count++;

				}
			}

		}

		public void switchQues()
		{
				
			btnA.Enabled = true;
			btnB.Enabled = true;
			btnC.Enabled = true;
			if (answerCount < 1)
				btnPreview.Hidden = true;
			else
				if(type == 1 || type == 2)
				btnPreview.Hidden = false;

			if (language != 0)
				RandomQuestions(answerCount);
			else
				RandomQuestionsCn(answerCount);
			
			answerCount++;

			if (type == 2)
			{
				if (language != 0)
					labelTitle.Text = "Praticle Review " + answerCount + "/" + reviewCount;
				else
					labelTitle.Text = "错题回顾 " + answerCount + "/" + reviewCount;

			}

			else
			{
				if (language != 0)
				{
					if (type == 1)
						labelTitle.Text = "Praticle Test " + answerCount + "/" + quesNumber.Length;
					else
						labelTitle.Text = "Quicke Test " + answerCount + "/" + quesNumber.Length;
				}

				else
				{
					if (type == 1)
						labelTitle.Text = "学习模式 " + answerCount + "/" + quesNumber.Length;
					else
						labelTitle.Text = "练习模式 " + answerCount + "/" + quesNumber.Length;
				}
			}
				
		}

		public void switchPrewQues()
		{
 			answerCount--;
			int temp = answerCount;
			temp--;

			if (language != 0)
				RandomQuestions(temp);
			else
				RandomQuestionsCn(temp);

;
			if (language != 0)
			{
				if (type == 1)
					labelTitle.Text = "Praticle Test " + answerCount + "/" + quesNumber.Length;
				else
					labelTitle.Text = "Quicke Test " + answerCount + "/" + quesNumber.Length;
			}

			else
			{
				if (type == 1)
					labelTitle.Text = "学习模式 " + answerCount + "/" + quesNumber.Length;
				else
					labelTitle.Text = "练习模式 " + answerCount + "/" + quesNumber.Length;
			}
			
			if (type == 2)
			{
				if (language != 0)
					labelTitle.Text = "Praticle Review " + answerCount + "/" + reviewCount;
				else
					labelTitle.Text = "错题回顾 " + answerCount + "/" + reviewCount;

			}
		}



		public bool indexOf(int element)
		{
			bool result = false;
			for (int i = 0; i < count; i++)
				if (element == quesNumber[i])
					return true;
			return result;
					
		}

		public void nextQues(int index, int ques)
		{
			if (index == 1)
			{
				if (correctAnswer == "2" || correctAnswer == "3")
				{
					WrongCount.Add(ques);
				}
					
				else
					{
					RightCount.Add(ques);
					Console.WriteLine("Tianjia");
					}
			}

			if (index == 2)
			{
				if (correctAnswer == "1" || correctAnswer == "3")
				{
					WrongCount.Add(ques);
				}				
				else
				{
					RightCount.Add(ques);
					Console.WriteLine("Tianjia");
				}
					
			}

			if (index == 3)
			{
				if (correctAnswer == "1" || correctAnswer == "2")
				{
					WrongCount.Add(ques);
				}
				else
				{
					RightCount.Add(ques);
					Console.WriteLine("Tianjia");
				}
			}

		}

		public void previewAnswer(int answer)
		{
			if (answer == 1)
			{

				if (correctAnswer == "1")
					btnA.BackgroundColor = UIColor.Green;

				if (correctAnswer == "2")
				{
					
					btnA.BackgroundColor = UIColor.Red;
					btnB.BackgroundColor = UIColor.Green;

				}

				if (correctAnswer == "3")
				{
					
					btnA.BackgroundColor = UIColor.Red;
					btnC.BackgroundColor = UIColor.Green;
				}

			}
			if (answer == 2)
			{

				if (correctAnswer == "1")
				{
					
					btnA.BackgroundColor = UIColor.Green;
					btnB.BackgroundColor = UIColor.Red;
				}

				if (correctAnswer == "2")
					btnB.BackgroundColor = UIColor.Green;


				if (correctAnswer == "3")
				{
					
					btnB.BackgroundColor = UIColor.Red;
					btnC.BackgroundColor = UIColor.Green;

				}

			}
			if (answer == 3)
			{

				if (correctAnswer == "1")
				{
					
					btnA.BackgroundColor = UIColor.Green;
					btnC.BackgroundColor = UIColor.Red;

				}
				if (correctAnswer == "2")
				{

					btnC.BackgroundColor = UIColor.Red;
					btnB.BackgroundColor = UIColor.Green;

				}

				if (correctAnswer == "3")
					btnC.BackgroundColor = UIColor.Green;
			}

		}

		//public void wrongNoCount(int ques)
		//{
		//	Console.WriteLine(ques);
		//	Wrong[countWrong] = ques;
		//	Console.WriteLine(Wrong[countWrong]);
		//	countWrong++;
		//}


		public void showAnswer(int index, int ques)
		{
			if (index == 1)
			{
				btnA.Enabled = false;
				btnB.Enabled = false;
				btnC.Enabled = false;

				if (correctAnswer == "1")
				{
					btnA.BackgroundColor = UIColor.Green;
					RightCount.Add(ques);
				}
					

				if (correctAnswer == "2")
				{
					WrongCount.Add(ques);
					btnA.BackgroundColor = UIColor.Red;
					btnB.BackgroundColor = UIColor.Green;
				}
					
				if (correctAnswer == "3")
				{
					WrongCount.Add(ques);
					btnA.BackgroundColor = UIColor.Red;
					btnC.BackgroundColor = UIColor.Green;
				}
					
			}
			if (index == 2)
			{
				btnA.Enabled = false;
				btnB.Enabled = false;
				btnC.Enabled = false;

				if (correctAnswer == "1")
				{
					WrongCount.Add(ques);
					btnA.BackgroundColor = UIColor.Green;
					btnB.BackgroundColor = UIColor.Red;
				}

				if (correctAnswer == "2")
				{
					btnB.BackgroundColor = UIColor.Green;
					RightCount.Add(ques);
				}
				

				if (correctAnswer == "3")
				{
					WrongCount.Add(ques);
					btnB.BackgroundColor = UIColor.Red;
					btnC.BackgroundColor = UIColor.Green;

				}

			}
			if (index == 3)
			{
				btnA.Enabled = false;
				btnB.Enabled = false;
				btnC.Enabled = false;

				if (correctAnswer == "1")
				{
					WrongCount.Add(ques);
					btnA.BackgroundColor = UIColor.Green;
					btnC.BackgroundColor = UIColor.Red;

				}
				if (correctAnswer == "2")
				{  
					WrongCount.Add(ques);
					btnC.BackgroundColor = UIColor.Red;
					btnB.BackgroundColor = UIColor.Green;

				}

				if (correctAnswer == "3")
				{
					btnC.BackgroundColor = UIColor.Green;
					RightCount.Add(ques);

				}
			}
		}


        public void RandomQuestions(int index)
        {
			QuestionNo = quesNumber[index];
			switch(quesNumber[index])
            {
                case 1:
                    lableQues.Text = "In which of these situations are you allowed to drive in a bus lane?";
                    btnA.SetTitle("A.When you plan to turn left in less than 100 metres", UIControlState.Normal);
                    btnB.SetTitle("B.When the traffic in other lanes has stopped moving", UIControlState.Normal);
                    btnC.SetTitle("C.When making a three point turn", UIControlState.Normal);
                    //btnD.SetTitle(null, UIControlState.Normal);
                    imageViewQues.Image = UIImage.FromFile("images/K0702.JPG");
                    correctAnswer = "1";



                    break;
                case 2:
                    lableQues.Text = "Kalista has a GPS navigation system in her car. She is only allowed to use this while driving if";
                    btnA.SetTitle("A.she can adjust it easily while driving.", UIControlState.Normal);
                    btnB.SetTitle("B.it is mounted to the car and does not distract her.", UIControlState.Normal);
                    btnC.SetTitle("C.she keeps it on her lap with the sound turned off.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "2";
                    break;
                case 3:
                    lableQues.Text = "A bus is stopped at a bus stop in a built­up area. The bus is indicating right. You see this sign on the back of the bus. What does it mean?";
                    btnA.SetTitle("A.You are not allowed to overtake the bus.", UIControlState.Normal);
                    btnB.SetTitle("B.The bus will give way to you if the road narrows.", UIControlState.Normal);
                    btnC.SetTitle("C.You must be prepared to let the bus pull into your lane.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/3.jpg");
                    correctAnswer = "3";
                    break;
                case 4:
                    lableQues.Text = "You are travelling along this road behind two motorcycles. The motorcycles are moving slowly. What should you do?";
                    btnA.SetTitle("A.Sound your horn so the motorcycles move to the left of the lane.", UIControlState.Normal);
                    btnB.SetTitle("B.Overtake the motorcycles slowly.", UIControlState.Normal);
                    btnC.SetTitle("C.Wait behind the motorcycles.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/4.jpg");
                    correctAnswer = "3";
                    break;
                case 5:
                    lableQues.Text = "You are driving in heavy traffic. What is a good way to reduce the amount of fuel you use?";
                    btnA.SetTitle("A.Accelerate quickly to keep up with the traffic flow.", UIControlState.Normal);
                    btnB.SetTitle("B.Try to avoid bursts of acceleration and deceleration.", UIControlState.Normal);
                    btnC.SetTitle("C.Take your vehicle out of gear as you approach the vehicle in front.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "2";
                    break;
                case 6:
                    lableQues.Text = "Which vehicle is NOT allowed to make a U­turn?";
                    btnA.SetTitle("A.Vehicle A", UIControlState.Normal);
                    btnB.SetTitle("B.Vehicle B", UIControlState.Normal);
                    btnC.SetTitle("C.Vehicle C", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/6.jpg");
                    correctAnswer = "2";
                    break;
                case 7:
                    lableQues.Text = "You are travelling at 50 km/h on a dry road. It takes 35 metres to stop. What happens when the road is wet?";
                    btnA.SetTitle("A.You need more than 35 metres to stop.", UIControlState.Normal);
                    btnB.SetTitle("B.You need less than 35 metres to stop.", UIControlState.Normal);
                    btnC.SetTitle("C.You need less than 35 metres to stop.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "1";
                    break;
                case 8:
                    lableQues.Text = "You are driving in a built up area. There are no signs indicating a speed limit. What is the maximum speed you are allowed to drive?";
                    btnA.SetTitle("A.40 km/h", UIControlState.Normal);
                    btnB.SetTitle("B.50 km/h", UIControlState.Normal);
                    btnC.SetTitle("C.60 km/h", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "2";
                    break;
                case 9:
                    lableQues.Text = "When are you allowed to use your vehicle's horn?";
                    btnA.SetTitle("A.When are you allowed to use your vehicle's horn?", UIControlState.Normal);
                    btnB.SetTitle("B.To let other drivers know that they are driving too fast", UIControlState.Normal);
                    btnC.SetTitle("C.To inform other drivers of a dangerous situation further along the road", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "1";
                    break;
                case 10:
                    lableQues.Text = "What should you do with your eyes while driving?";
                    btnA.SetTitle("A.Focus your eyes on the vehicle in front.", UIControlState.Normal);
                    btnB.SetTitle("B.Keep watching the traffic all around you.", UIControlState.Normal);
                    btnC.SetTitle("C.Keep your eyes fixed on the rear view mirror.", UIControlState.Normal);
                    //btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
                    correctAnswer = "2";
                    break;
            }
          

        }

		public void RandomQuestionsCn(int index)
		{
			QuestionNo = quesNumber[index];
			switch (quesNumber[index])
			{
				case 1:
					lableQues.Text = "在哪种情况下，你允许使用公交专用道？";
					btnA.SetTitle("A.当你计划左转不到100米", UIControlState.Normal);
					btnB.SetTitle("B.当其它车道的交通已经停止移动", UIControlState.Normal);
					btnC.SetTitle("C.当你进行三点掉头", UIControlState.Normal);
					//btnD.SetTitle(null, UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/K0702.JPG");
					correctAnswer = "1";
					break;
				case 2:
					lableQues.Text = "Kalista在她的车内具有GPS导航系统，以下哪种情况她允许GPS";
					btnA.SetTitle("A.Kalista可以在驾驶时随时使用GPS", UIControlState.Normal);
					btnB.SetTitle("B.将GPS安装到不会干扰Kalista驾驶的位置", UIControlState.Normal);
					btnC.SetTitle("C.Kalista将GPS放在腿上并将声音关掉", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "2";
					break;
				case 3:
					lableQues.Text = "一辆巴士停在巴士站并闪烁右方向灯。你在巴士后面并看见巴士有以下标志，这是什么意思?";
					btnA.SetTitle("A.你不允许超车", UIControlState.Normal);
					btnB.SetTitle("B.如果道路变窄，巴士将让你先行", UIControlState.Normal);
					btnC.SetTitle("C.你必须准备让行", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/3.jpg");
					correctAnswer = "3";
					break;
				case 4:
					lableQues.Text = "你开车所在的路上有两辆速度很慢的摩托车在你的前方，你应该做什么?";
					btnA.SetTitle("A.按车喇叭提醒摩托车移动到路得左边", UIControlState.Normal);
					btnB.SetTitle("B.慢慢的超过两辆摩托车", UIControlState.Normal);
					btnC.SetTitle("C.继续保持车辆在摩托车的后方", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/4.jpg");
					correctAnswer = "3";
					break;
				case 5:
					lableQues.Text = "你行驶在高速公路上，哪个好的方法可以减少燃油的使用量?";
					btnA.SetTitle("A.加速赶上车流", UIControlState.Normal);
					btnB.SetTitle("B.尽量避免突然地加速和减速.", UIControlState.Normal);
					btnC.SetTitle("C.使车辆不受控制当接近前方的车辆", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "2";
					break;
				case 6:
					lableQues.Text = "那辆车不允许掉头?";
					btnA.SetTitle("A.Vehicle A", UIControlState.Normal);
					btnB.SetTitle("B.Vehicle B", UIControlState.Normal);
					btnC.SetTitle("C.Vehicle C", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = UIImage.FromFile("images/6.jpg");
					correctAnswer = "2";
					break;
				case 7:
					lableQues.Text = "你以50公里每小时的速度行驶在一条干燥的路上，需要行驶35米才能使车辆停下，那么在湿滑的路面上呢？";
					btnA.SetTitle("A.你需要行驶超过35米才能停下", UIControlState.Normal);
					btnB.SetTitle("B.你需要行驶少于35米才能停下", UIControlState.Normal);
					btnC.SetTitle("C.You need less than 35 metres to stop.", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "1";
					break;
				case 8:
					lableQues.Text = "你行驶在没有限速标志的一个施工的区域，此时你最高可以行驶的速度是?";
					btnA.SetTitle("A.40 公里每小时", UIControlState.Normal);
					btnB.SetTitle("B.50 公里每小时", UIControlState.Normal);
					btnC.SetTitle("C.60 公里每小时", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "2";
					break;
				case 9:
					lableQues.Text = "什么时候你可以使用你汽车的喇叭?";
					btnA.SetTitle("A.When are you allowed to use your vehicle's horn?", UIControlState.Normal);
					btnB.SetTitle("B.提醒其他车辆的驾驶员，他的车速太快", UIControlState.Normal);
					btnC.SetTitle("C.告知其他车辆，这条路上有危险", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "1";
					break;
				case 10:
					lableQues.Text = "在开车时，你的眼睛应该干嘛?";
					btnA.SetTitle("A.注视车辆的前方", UIControlState.Normal);
					btnB.SetTitle("B.时刻关注周围的车流", UIControlState.Normal);
					btnC.SetTitle("C.一直盯着后视镜.", UIControlState.Normal);
					//btnD.SetTitle("D.YHXYD", UIControlState.Normal);
					imageViewQues.Image = null;
					correctAnswer = "2";
					break;
			}


		}

    }
}
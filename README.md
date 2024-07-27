[ 가상  댄스  튜토리얼  솔루션  ]   
모션캡처 기술활용 가상댄스 튜토리얼   

대표학생 : 김대영 (로그메타 팀)    
참여학생 : 김대영, 심우현, 박지훈    

[ 가상  댄스  튜토리얼  솔루션  ]   
사용자가  가상의  캐릭터와  함께   
댄스를 배우고 연습할 수 있는 솔루션입니다.    

▲ 전문 장비가 아닌 일반 장비 (PC, 웹캠) 사용    
▲ 사용자 실시간 추적    
▲ 원본 영상과 사용자의 춤 영상간의 정확도 (피드백) 산출     
▲ 가상 캐릭터와 함께 댄스     

------------------------------------------------------------------------------------------------

[ 작품 결과 ]    
[ 모드  선택지  (테스트  모드  / 연습  모드) ]    

[ 테스트 모드 - 선택지 1 ]    
![image](https://github.com/user-attachments/assets/9694125f-01d0-469b-9a43-35678665b30d)    
웹캠 '사용자 움직임'을 캐릭터가 따라 한다.     
(원본 영상 춤 X, 사용자 춤 O)    

[ 테스트 모드 - 선택지 2 ]    
![image](https://github.com/user-attachments/assets/b23464c1-3b74-417f-886d-8bcfca89d518)    
'원본 영상 속 인물 움직임'을 캐릭터가 따라 한다.     
(원본 영상 춤 O, 사용자 춤 X)    

[ 연습모드 (피드백 제공) ]    
![image](https://github.com/user-attachments/assets/5fe335bc-9b8e-460a-89b2-780c058ad536)    
유사도 비교 피드백 제공 (유클리드 거리)    


------------------------------------------------------------------------------------------------
(1) 참고 도서    
“초보자를 위한 유니티 입문” - 한빛미디어     
“레트로의 유니티 게임 프로그래밍 에센스” - 한빛미디어     
“인생 유니티 교과서” – 성안당    
    
(2) 참고 라이브러리    
* ThreeDPoseUnityBarracuda     
- 유니티에서 Barracuda를 사용하여 캐릭터 움직일 수 있게 하는 라이브러리      
* UniVRM 0.51.1     
- Unity에서 VRM 모델을 다루기 위한 라이브러리     
* BVH Tools BVH (Biovision Hierarchy)     
- 파일을 처리하고 애니메이션 데이터를 가져오는 툴     
* Unity Standalone File Browser 1.2     
- Unity에서 파일 열기/저장 대화상자를 제공하는 독립형 파일 브라우저     
* uOSC 0.0.2    
- Unity에서 OSC (Open Sound Control) 프로토콜을 사용하기 위한 라이브러리     
* Unity Capture    
- Unity에서 비디오 캡처 기능을 제공하여 화면을 녹화하거나 스트리밍할 수 있는 도구     
* Oculus Lipsync Unity 20.0.0    
- Oculus에서 제공하는 실시간 립싱크 애니메이션을 위한 Unity 플러그인     
* Final IK    
- Unity에서 캐릭터 애니메이션에 고급 IK (Inverse Kinematics) 솔루션을 제공하는 플러그인     
* The Charterhouse Great Chamber glTF Data    
The Charterhouse의 Great Chamber를 glTF 형식으로 저장한 데이터 세트    

(3) 참고 논문     
* A-simple-yet-effective-baseline-for-3d-human-pose-estimation     
- 3D 인간 포즈 추정을 위한 간단하지만 효과적인 기준선을 제안하는 연구    

* 3D 인간 자세 추정 AI     
- HumanEVA-I model     
https://arxiv.org/abs/2103.14304    
https://arxiv.org/pdf/2303.11579v1.pdf    
https://arxiv.org/pdf/2307.05853v2.pdf    

* 동작 유사도 분석 
- 코사인 유사도, DTW 

--------------------------------------------------------------------------------------
[Virtual dance tutorial solution]   
Virtual Dance Tutorial Using Motion Capture Technology   

Representative Student: Kim Dae-young (Logmeta Team)   
Participating students: Kim Dae-young, Shim Woo-hyun, Park Ji-hoon   

[Virtual dance tutorial solution]   
The user will join the virtual character   
It's a solution where you can learn and practice dancing.   

▲ Use general equipment (PC, webcam) rather than professional equipment   
▲ Real-time tracking of users   
▲ Calculate accuracy (feedback) between the original video and the user's dance video   
▲ Dance with Virtual Characters   

[Result of his work]   
[MODE CHOICE (Test mode/Practice mode)]   

[Test mode - Option 1]   
The character imitates the webcam 'user movement'.   
(Original video dance X, user dance O)   

[Test mode - Option 2]   
The character imitates the movement of the character in the original video.   
(O original video dance, X user dance)   

[Practice mode (feedback provided)]   
Provide similarity comparison feedback (Euclidean distance)   


---------------------------------------------------------------------------------------
(1) a reference book   
"Introduction to UNI.T for beginners". - Hanbit Media   
"Retro's Unity Game Programming Essence". - Hanbit Media   
"Life UNI.T. textbook" – Sung Andang   

(2) Reference Library   
ThreeDPoseUnityBarracuda   
Libraries that allow Unity to move characters using Barracuda   
UniVRM 0.51.1   
Library for dealing with VRM models in Unity   
BVH Tools BVH (Biovision Hierarchy)   
Tools to process files and import animation data   
Unity Standalone File Browser 1.2   
Standalone file browser that provides an Open/Save file dialog in Unity   
uOSC 0.0.2   
Library for using the Open Sound Control (OSC) protocol in Unity   
Unity Capture   
A tool that allows Unity to record or stream your screen by providing video capture capabilities   
Oculus Lipsync Unity 20.0.0   
Unity Plug-in for Live Lip Sync Animation from Oculus   
Final IK   
Plug-in provides advanced inverse kinematics (IK) solutions for character animation in Unity   
The Charterhouse Great Chamber glTF Data   
Data set that stores The Charterhouse's Great Chamber in glTF format   


(3) a reference paper   
A-simple-yet-effective-baseline-for-3d-human-pose-estimation   
A study that proposes a simple but effective baseline for 3D human pose estimation   
3D Human Posture Estimation AI   

HumanEVA-I model   
https://arxiv.org/abs/2103.14304   
https://arxiv.org/pdf/2303.11579v1.pdf   
https://arxiv.org/pdf/2307.05853v2.pdf   

Behavioral Similarity Analysis   
Cosine Similarity, DTW   

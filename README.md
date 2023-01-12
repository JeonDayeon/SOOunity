여성향 게임에서 살아남기
==

<br>

- - -
### + 2022.06.01 작업현황
- 캐릭터 이동 구현 완료
- 카메라 동작 구현 완료
- 충돌 구현 완료(Boxcollider 이용)
- 맵이동 구현 완료
- SoundManager 구현 진행 중
- 일부 UI 제작 진행 중(스크립트 및 설정)

### + 2022.08.16 작업현황
- 카메라 영역 재설정
- 플레이어 스프라이트 변경
- BGM 재생 구현
- 캐릭터 이동시 효과음 적용
- Script UI 일부 캔버스 배치
- 스크립트 구현 진행 중

### + 2022.10.20 작업현황
 - 비주얼노벨 씬 및 스크립트 제작 (60% 완료)
 - 맵 제작 완료
 - 대화창 및 퀘스트 구현(오류가 있어 수정해야함)
 - 일부 UI 변경
 - 쯔꾸르 진행 중 끼임 현상 확인
 - 미니게임 작업 진행
 - 쯔꾸르에 라이트 추가
 - 쯔꾸르 퀘스트 상호작용 구현
 
### + 2022.11.17 작업현황
- 퀘스트 오류 해결
- 미니게임 완성
- 비주얼 노벨 완성
- 비주얼 노벨 진행 방식 변경(마우스 우측 버튼으로 진행 -> 마우스 우측 버튼 + 스페이스바)
- 비주얼 노벨 진행 방식에 맞춰 쯔꾸르 퀘스트 키도 변경
- SFX 구현 및 BGM 재배치
- 게임 진행에 맞춰 GameLoad 구현
- UI 일부 변경
- 끼임 현상 해결X(임시 방편으로 끼일시 시작위치로 복귀 할 수 있도록 해놓음)

### + 2022.11.18 작업현황
 - 비주얼 노벨 Fade In & Out에서 오류 발생 확인
 - 게임 진행 중에 있던 잡다한 오류 수정
 
### + 2022.01.10 작업현황
 - 일부 UI 수정 및 그래픽 소스 수정
 - Fade in & out 오류 수정 진행 중
 - 메인화면 UI 배치 완료
 - Save, Load 구현 진행 중
 - 메인화면 이동 
* * *
<br>


## 캐릭터 이동 구현 코드
### [MoveObject.cs](https://github.com/JeonDayeon/SOOunity/blob/d3e6e1b3c6fcfb5493c52bb2fdde77c8c439d1cf/SurviverOfOtome/Assets/Unan/Scripts/MovingObjects.cs)


## 카메라 동작 구현 코드
### [CameraManager.cs](https://github.com/JeonDayeon/SOOunity/blob/8fe593be4c146a1c26142b23a383ff09a823e354/SurviverOfOtome/Assets/Unan/Scripts/CameraManager.cs)

## 맵이동 구현 코드
### [TransferMap.cs](https://github.com/JeonDayeon/SOOunity/blob/main/SurviverOfOtome/Assets/Unan/Scripts/TransferMap.cs)

## BGM 재생 구현 코드
### [BGMmanager.cs](SurviverOfOtome/Assets/Unan/Scripts/BGMmanager.cs)
<br>

* * *
## 인게임 화면
![image](https://user-images.githubusercontent.com/95409013/173210175-9ef3427c-8837-485e-b663-ee71edced1da.png)
2022.06.01<br/>
![image](https://user-images.githubusercontent.com/95409013/184805476-70ff440b-3376-4be8-917e-14eb26b0e36f.png)
2022.08.16<br/>
![비주얼노벨](https://user-images.githubusercontent.com/95409013/211444132-8cb30a9f-98f1-4b13-b3cc-1914cd336a5b.png)
![비주얼노벨](https://user-images.githubusercontent.com/95409013/211444188-8a3118ef-4fcb-491e-b5d4-84ea693b17ec.png)
![쯔꾸르](https://user-images.githubusercontent.com/95409013/211443725-56b6ed12-c01e-4148-bea7-afc5bc5e68b2.png)
![미니게임](https://user-images.githubusercontent.com/95409013/211443907-8ef38d0f-9da7-43ba-a513-63578b003fd3.png)
2022.11.17<br/>
---
## 기능 구현 영상
### Walk
![walk](https://user-images.githubusercontent.com/95409013/173212974-449be5bc-cba5-4c35-82d8-7452b0fb435d.gif)

### Run
![Run](https://user-images.githubusercontent.com/95409013/173212990-8992a8c7-15ac-4bbc-83b7-fded8ff4769a.gif)

### Crash
![Crash](https://user-images.githubusercontent.com/95409013/173213007-21e6a00f-d0c5-4dd1-bedc-fe4250fcb42b.gif)

### TransferMap
![TransferMap](https://user-images.githubusercontent.com/95409013/173213131-7a61fe7b-1e87-4695-b422-20968c0adf3d.gif)
* * *

原版POS機架構圖，將前後端分離，並將order和display劃分，利用eventhandlers來顯示畫面
![image](https://github.com/user-attachments/assets/9c99bfd0-a34a-408f-9464-cc4628426655)
簡單工廠實作架構圖，是以資料流為思考去設計，我只在order跟display中，去插入簡單工廠，來做到不更動原本程式碼(orp)，來做到策略的使用。
![image](https://github.com/user-attachments/assets/30b045ee-aadc-4776-b392-3a81e251ca40)
策略模式實作架構圖。主要是將簡單工廠改為策略模式，比較發現這個專案更適合，策略模式，因為它著重於行為的封裝，在這邊因為折扣屬於同一種行為，故這邊更適合。
![image](https://github.com/user-attachments/assets/6427051d-4ee0-44ac-9bfe-1dcafd666879)



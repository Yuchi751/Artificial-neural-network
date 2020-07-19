# Artificial-neural-network 

### 實作 OR AND XOR 

- 使用類神經網路(NN)對AND OR XOR問題，看使否收斂
- 初學者
- 這只是作業，如有錯誤請多包涵
- This is Homework , So may be have some bug
- 作者：邱

### 方法 

AND、OR使用單層的感知器去做運算(如下附圖)
![單層感知器](https://github.com/Yuchi751/Artificial-neural-network/blob/master/images/%E5%96%AE%E5%B1%A4%E6%84%9F%E7%9F%A5%E5%99%A8.png?raw=true "單層感知器")

XOR使用多層的感知器去做的(如下附圖)
![多層感知器](https://github.com/Yuchi751/Artificial-neural-network/blob/master/images/%E5%A4%9A%E5%B1%A4%E6%84%9F%E7%9F%A5%E5%99%A8.png?raw=true "多層感知器")

### AND、OR程式想法

- 不套用函式庫的方式
- 使用C#

#### 參考公式
![image](https://github.com/Yuchi751/Artificial-neural-network/blob/master/images/Sign.png?raw=true)

透過輸入值去和設定的權重去相乘，而該變量是這兩個得連接，每個輸入值都會搭配不同的權重，然後會得出期望值去減掉實際輸出，透過100次的迭代去收斂出最接近0的。
使用C#去寫，最後匯出文字檔，再到excel畫圖呈現。

**程式碼可看form1.cs**

### XOR程式想法

- 使用numpy與tensorflow
- 使用Python

**程式碼可看XOR.py**
# -*- coding: utf-8 -*-
"""
Created on Sat Jan  4 13:57:25 2020

@author: Windows 10
"""

import matplotlib.pyplot as plt
import numpy as np
import tensorflow as tf

# 定義輸入和目標
x_ = np.array([[0, 0], [1, 0], [0, 1], [1, 1]])
y_ = np.array([[0], [1], [1], [0]])

# 定義權重和訓練參數
X = tf.placeholder(shape=(None, 2), dtype=tf.float32)
w1 = tf.Variable(tf.random_normal(shape=(2,4)))
b1 = tf.Variable(tf.random_normal(shape=(1,4)))
w2 = tf.Variable(tf.random_normal(shape=(4,1)))
b2 = tf.Variable(tf.random_normal(shape=(1,1)))
y = tf.placeholder(shape=(4,1), dtype=tf.float32)

# 定義隱藏層與輸出層
hidden_layer = tf.sigmoid(tf.matmul(X, w1) + b1)
output_layer = tf.sigmoid(tf.matmul(hidden_layer, w2) + b2)

# 損失函數
loss = tf.reduce_sum(tf.square(y - output_layer))
# 訓練方法，建立優化器
train = tf.train.AdamOptimizer(learning_rate=0.05).minimize(loss)
# 初始化計算圖
init = tf.global_variables_initializer()
sess = tf.Session()
sess.run(init)

# 訓練類神經網路
losses = []
epochs = 1000
for epoch in range(epochs+1):
    sess.run(train, feed_dict={X: x_, y: y_})
    if epoch % 100 == 0:
        losses.append(sess.run(loss, feed_dict={X: x_, y: y_}))

# 繪製曲線
plt.figure(figsize=(8, 4))
plt.plot(np.linspace(0, 1000, 11), losses)
plt.xticks(np.linspace(0, 1000, 11))
plt.xlabel('Epochs')
plt.ylabel('Loss')
plt.show()
sess.close()

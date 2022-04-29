# -*- coding: utf-8 -*-
"""Deep_Learning_Models.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1rdmoynRzc64JM8SVdKjS1k6vGzttt4RU
"""

import cv2
import glob
import numpy as np
import matplotlib.pyplot as plt
from tensorflow.keras.layers import Dense, Conv2D, Dropout, BatchNormalization, Input, LeakyReLU, Flatten, Dropout
from tensorflow.keras.optimizers import Adam
from tensorflow.keras import Model
from sklearn.pipeline import make_pipeline
from sklearn.preprocessing import StandardScaler
from sklearn.svm import LinearSVC
from sklearn.datasets import make_classification
from sklearn import metrics
from sklearn.metrics import classification_report, confusion_matrix
import pandas as pd
import seaborn as sns
from tensorflow.keras.utils import to_categorical
from tensorflow.keras.utils import plot_model

!gdown --id 1leY5kJRbk4URDuciIx2EqN5n3GtvdrMS

!unzip 'EEG_Dataset.zip'

directories = glob.glob('archive/GAMEEMO/*')
dir_len = len(directories)
for i in range(dir_len):
  directories[i] += '/Preprocessed EEG Data/*'
  directories[i] = glob.glob(directories[i])

raw_eeg= []
labels = []
for p in directories:
  for r in p:
    l = r.split('/')[-1][4]
    Df = pd.read_csv(r)
    raw_eeg.append(Df.iloc[0:,0:14].values.tolist())
    labels.append(int(l)-1)

n = len(raw_eeg)
# train_range = int(n*0.8)
# train_X = []
# train_Y = []
# for i in range(train_range):
#   for row in raw_eeg[i]:
#     train_X.append(row)
#     train_Y.append(labels[i])
# train_Y_onehot = to_categorical(train_Y)
train_X = np.array(raw_eeg[0:int(n*0.8)])
train_Y = np.array(to_categorical(labels[0:int(n*0.8)],num_classes=4))
test_X = np.array(raw_eeg[int(n*0.8):])
test_Y = np.array(labels[int(n*0.8):])
# for i in range(train_range,participants):
#   for row in raw_eeg[i]:
#     test_X.append(row)
#     test_Y.append(labels[i])
# test_Y_onehot = to_categorical(test_Y)

inputs = Input(shape=train_X.shape[1:])
x = Flatten()(inputs)
x = Dense(units=50)(x)
x = LeakyReLU()(x)
x = Dropout(rate=0.2)(x)
x = Dense(units=50)(x)
x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=200)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=200)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=200)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=128)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=32)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
outputs = Dense(units=4,activation='softmax')(x)
model = Model(inputs=inputs, outputs=outputs)
#print model summary here
model.summary()

plot_model(model, "DL.png", show_shapes=True)

batch_size = 10
lr = 10e-6
epochs=25

model.compile(optimizer=Adam(learning_rate=lr), metrics=['accuracy'], loss='categorical_crossentropy')

history = model.fit(x=train_X,y=train_Y,epochs=epochs,
                 batch_size=batch_size,validation_split=0.1)

plt.plot([i for i in range(epochs)], history.history['loss'], 'r-', label="Training Loss")
plt.plot([i for i in range(epochs)], history.history['val_loss'], 'b-', label="Validation Loss")
plt.xlabel("Epoch")
plt.ylabel("Cross-Entropy Loss")
plt.title("Loss Curve")
plt.legend(loc="upper right")
plt.show()

plt.plot([i for i in range(epochs)], history.history['accuracy'], 'r-', label="Training accuracy")
plt.plot([i for i in range(epochs)], history.history['val_accuracy'], 'b-', label="Validation accuracy")
plt.xlabel("Epoch")
plt.ylabel("Cross-Entropy Loss")
plt.title("Accuracy Curve")
plt.legend(loc="upper right")
plt.show()

pred_labels = model.predict(test_X).argmax(axis=1)
correct = 0
total = len(pred_labels)
for i in range(total):
  if pred_labels[i] == test_Y[i]:
    correct += 1
accuracy = correct/total
print("Test Accuracy:",accuracy*100)

cm = confusion_matrix(test_Y, pred_labels)
# dictionary = {0:'Bored',1:'Calm',2:'Horrified',3:'Happy'}
# dictionary[test_Y]
['Bored','Calm','Horrified','Happy']

def plot_confusion_matrix(conf_mat):
  classes = list(labels)
  df_cm = pd.DataFrame(conf_mat,columns=['Bored','Calm','Horrified','Happy'],index=['Bored','Calm','Horrified','Happy'])
  plt.figure(figsize=(10,7))
  sns.set(font_scale=1.4)
  sns.heatmap(df_cm, annot=True,annot_kws={"size": 16})
  plt.show()

plot_confusion_matrix(cm)

print(classification_report(test_Y, pred_labels,target_names=['Bored','Calm','Horrified','Happy']))

"""# CNN"""

# inputs = Input(shape=train_X.shape[1:])
# x = Flatten()(inputs)
# x = Dense(units=50)(x)
# x = LeakyReLU()(x)
# x = Dropout(rate=0.2)(x)
# x = Dense(units=50)(x)
# x = LeakyReLU()(x)
X_shape = train_X.shape
X_train_conv = train_X.reshape(-1,X_shape[1],X_shape[2],1)
X_test_conv = test_X.reshape(-1,X_shape[1],X_shape[2],1)

inputs = Input(shape=X_test_conv.shape[1:])
x = Conv2D(filters=10,kernel_size=(5,5),strides=(2,2),padding='same')(inputs)
x = BatchNormalization()(x)
x = LeakyReLU()(x)
x = Dropout(rate=0.2)(x)
x = Conv2D(filters=5,kernel_size=(3,3),strides=(2,2),padding='same')(x)
x = BatchNormalization()(x)
x = LeakyReLU()(x)
x = Dropout(rate=0.2)(x)
x = Flatten()(x)
x = Dense(units=5)(x)
x = LeakyReLU()(x)
x = Dropout(rate=0.2)(x)
outputs = Dense(units=4,activation='softmax')(x)
model_conv = Model(inputs=inputs, outputs=outputs,name='CNN')
model_conv.summary()
# plot_model(model_conv,"model.png")

batch_size = 10
lr = 10e-6
epochs=40
model_conv.compile(optimizer=Adam(learning_rate=lr), metrics=['accuracy'], loss='categorical_crossentropy')

lr = 1e-2
lr

history = model_conv.fit(x=X_train_conv,y=train_Y,epochs=epochs,
                 batch_size=batch_size,validation_split=0.1)

plt.plot([i for i in range(epochs)], history.history['loss'], 'r-', label="Training Loss")
plt.plot([i for i in range(epochs)], history.history['val_loss'], 'b-', label="Validation Loss")
plt.xlabel("Epoch")
plt.ylabel("Cross-Entropy Loss")
plt.title("Loss Curve")
plt.legend(loc="upper right")
plt.show()

plt.plot([i for i in range(epochs)], history.history['accuracy'], 'r-', label="Training accuracy")
plt.plot([i for i in range(epochs)], history.history['val_accuracy'], 'b-', label="Validation accuracy")
plt.xlabel("Epoch")
plt.ylabel("Cross-Entropy Loss")
plt.title("Accuracy Curve")
plt.legend(loc="upper right")
plt.show()

pred_labels = model_conv.predict(X_test_conv).argmax(axis=1)
correct = 0
total = len(pred_labels)
for i in range(total):
  if pred_labels[i] == test_Y[i]:
    correct += 1
accuracy = correct/total
print("Test Accuracy:",accuracy*100)

cm = confusion_matrix(test_Y, pred_labels)
plot_confusion_matrix(cm)

print(classification_report(test_Y, pred_labels,target_names=['Bored','Calm','Horrified','Happy']))
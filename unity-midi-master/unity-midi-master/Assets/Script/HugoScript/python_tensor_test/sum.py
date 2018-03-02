from __future__ import absolute_import
from __future__ import division
from __future__ import print_function
from random import randint
import tensorflow as tf
import numpy as np



flags = tf.app.flags
FLAGS = flags.FLAGS
flags.DEFINE_integer('batch_size', 50, 'Batch size.')
flags.DEFINE_float('learning_rate', 0.01, 'Initial learning rate.')
flags.DEFINE_integer('dim1', 3, 'layer size')
flags.DEFINE_integer('training_epochs', 10, 'Number of passes through the main training loop')
flags.DEFINE_integer('num_iters', 100, 'Number of iterations')
def main(argv):
    print("main")
    run_training()

def ezString(list):
    #debugging code so I can see what is going on
    listLength = len(list)
    r = ''
    for i in range(listLength):
        value = list[i]
        valueString = str(value)
        r = r + ' '
        r = r + valueString
    return r

def generateTrial():
    inputs = np.zeros(2, dtype = np.float)
    for i in range(2):
        inputs[i] = randint(0, 1)
    unknownInput = randint(0, 1)
    sum = 0
    for j in range(2):
        sum = sum + inputs[j]
    sum = sum + unknownInput
    inputTensor = np.asarray(inputs)
    return inputTensor, sum

def printTensor(tensor):
    sh = tensor.get_shape()
    print(sh)
    print("printed ")

def placeholder_inputs(size):
    output_placeholder = tf.placeholder(tf.float32, shape=(size))
    input_placeholder = tf.placeholder(tf.float32, shape=(size, 2))
    return input_placeholder, output_placeholder

def fill_feed_dict(inputs_pl, output_pl):
    inputs = []
    outputs = []
    for i in range(FLAGS.batch_size):
        input, output = generateTrial()
        inputs.append(input)
        outputs.append(output)

    return {inputs_pl: inputs, output_pl: outputs}

def loss(y, pred):
    return tf.reduce_mean(tf.pow(y - pred, 2))

def NN(x, y, W1, b1, W2, b2):
    layer1 = tf.add(tf.matmul(x, W1), b1)
    layer1 = tf.nn.relu(layer1)
    output = tf.add(tf.matmul(layer1, W2), b2)
    return output, loss(y, output)

def get_params(dim_hidden):
    with tf.variable_scope('nn_params'):
        return tf.Variable(tf.truncated_normal([2, dim_hidden], stddev = 0.05)), tf.Variable(0.0, (dim_hidden)),\
        tf.Variable(tf.truncated_normal([dim_hidden, 1], stddev = 0.05)), tf.Variable(0.0, 1)

def run_training():
    input_placeholder, output_placeholder = placeholder_inputs(FLAGS.batch_size)
    W1, b1, W2, b2 = get_params(FLAGS.dim1)
    print("sum is %s + %s =" % (W1.value, b1))
    pred, loss = NN(input_placeholder, output_placeholder, W1, b1, W2, b2)
    print(pred)
    optm = tf.train.AdamOptimizer(FLAGS.learning_rate).minimize(loss)
    init = tf.initialize_all_variables()
    sess = tf.Session()
    sess.run(init)

    for iters in range(FLAGS.num_iters):
        l, _ = sess.run([loss, optm], feed_dict = fill_feed_dict(input_placeholder, output_placeholder))
       # print (l, iters + 1)
if __name__ == '__main__':
    tf.logging.set_verbosity(tf.logging.INFO)
    tf.app.run(main)
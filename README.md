# TC Codes Fall Cohort Emailer

[![codecov](https://codecov.io/gh/tccodes-repo/full-stack-fall-2020/branch/master/graph/badge.svg)](https://codecov.io/gh/tccodes-repo/full-stack-fall-2020)
![Build](https://github.com/tccodes-repo/full-stack-fall-2020/workflows/Build/badge.svg)

The following directions assume you have already downloaded the
.net Core SDK [https://dotnet.microsoft.com/download]

Setting up your development environment:

Getting the App Running
(on a Mac)

Setting up your working environment.

1.You should create a fork in GitHub [https://github.com/tccodes-repo/full-stack-fall-2020]

2.git clone [https://github.com/tccodes-repo/full-stack-fall-2020.git] clone the repo to your local machine.

3.cd full-stack-fall-2020

4.cd api

5.cd Emailer

6.dotnet build

7.dotnet run ( I had to run this a couple of times as the it did not connect right away.)

8.At this point you should be able to open a browser window at
[https://localhost:5001/weatherforecast] and see the the "weatherforecast" project. (I had a security warning the first time I attempted to run this project locally, adjust you settings accordingly)

9.control c

10.cd ../..

11.cd ui

12.At this point you should be in the ui folder at this point

13.npm install

14.npm start -- you browser may automatically go to
[http://localhost:3000/] and you should see the React logo with the Learn React link at the bottom. If not, please feel free to start up the React portion of the app at the listed location
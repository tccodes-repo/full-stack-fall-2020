# TC Codes Fall Cohort Emailer

[![codecov](https://codecov.io/gh/tccodes-repo/full-stack-fall-2020/branch/master/graph/badge.svg)](https://codecov.io/gh/tccodes-repo/full-stack-fall-2020)
![Build](https://github.com/tccodes-repo/full-stack-fall-2020/workflows/Build/badge.svg)

The following directions assume you have already downloaded the
.net Core SDK [https://dotnet.microsoft.com/download]

Getting the App Running:
(on a Mac)

1.You should create a fork in GitHub [https://github.com/tccodes-repo/full-stack-fall-2020]

2.<code>git clone 'your forked version of /full-stack-fall-2020.repo'</code>the repo to your local machine.

3.<code>cd full-stack-fall-2020</code>

4.<code>cd api</code>

5.<code>cd Emailer</code>

6.<code>dotnet build</code>

7.<code>dotnet run</code>

8.At this point you should be able to open a browser window at
[https://localhost:5001/swagger/index.html] and see the Swagger interface. I had to run <code>dotnet run</code> a couple of times as my machine did not connect right away. I also had a security warning the first time I attempted running this project locally, adjust you settings accordingly. (Or use the HTTP interface at [http://localhost:5000/swagger/index.html].)

9.control c

10.<code>cd ../..</code>

11.<code>cd ui</code>

12.At this point you should be in the ui folder

13.<code>npm install</code>

14.<code>npm start</code> -- you browser may automatically go to
[http://localhost:3000/] and you should see the React logo with the Learn React link at the bottom. If not, please feel free to start up the React portion of the app at the listed location


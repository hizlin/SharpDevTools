//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            Test5();
//            // Test6();

//            // Console.WriteLine("Hello World!");

//            Console.ReadLine();
//        }

//        static void Test6()
//        {
//            TestNpm.Test1().Wait();
//        }

//        static void Test5()
//        {
//            var services = new ServiceCollection();
//            services.AddHttpClient();
//            services.AddTransient<TestCheck>();

//            var provider = services.BuildServiceProvider();
//            var test = provider.GetRequiredService<TestCheck>();

//            try
//            {
//                // test.Test3("com.squareup.okhttp3", "okhttp", "3.x").Wait();
//                test.Test3("org.apache.shardingsphere", "shardingsphere-jdbc-core", null).Wait();
//                test.Test3("org.apache.shardingsphere.elasticjob", "elasticjob-lite-core", null).Wait();


//                test.Test3("com.baomidou", "mybatis-plus", null).Wait();
//                // test.Test3("org.springframework.boot", "spring-boot-starter-web", null).Wait();
//                test.Test3("com.squareup.retrofit2", "retrofit", null).Wait();

//                test.Test3("com.github.binarywang", "weixin-java-miniapp", null).Wait();
//                test.Test3("com.github.xiaoymin", "knife4j-spring-boot-starter", null).Wait();



//                test.Test3("com.alibaba.cloud", "spring-cloud-alibaba-dependencies", null).Wait();
//                test.Test3("com.alibaba.nacos", "nacos-client", null).Wait();
//                test.Test3("io.seata", "seata-core", null).Wait();
//                test.Test3("com.alibaba.csp", "sentinel-core", null).Wait();
//                test.Test3("org.apache.rocketmq", "rocketmq-client", null).Wait();
//                // test.Test3("", "", null).Wait();
//                // test.Test3("", "", null).Wait();
//                // test.Test3("", "", null).Wait();

//            }
//            catch (Exception exc)
//            {
//                Console.WriteLine(exc.ToString());
//            }
//        }

//        async static Task Test4()
//        {
//            var services = new ServiceCollection();
//            services.AddHttpClient();
//            services.AddTransient<Test>();

//            var provider = services.BuildServiceProvider();
//            var test = provider.GetRequiredService<Test>();

//            try
//            {

//                // Test1().Wait();

//                // test.Test3("com.squareup.okhttp3","okhttp").Wait();
//                // test.Test3("org.springframework.boot", "spring-boot-starter-web").Wait();

//                //test.TestAliyun().Wait();
//                // Test2().Wait();
//                Test3();
//            }
//            catch (Exception exc)
//            {
//                Console.WriteLine(exc.ToString());
//            }
//        }

//        async static Task Test1()
//        {

//            var repo = MavenRepository.FromMavenCentral();
//            // await repo.Refresh("com.squareup.okhttp3");
//            await repo.Refresh("org.springframework.boot");

//            var groups = repo.Groups;

//            // var last = await repo.GetProjectAsync("com.squareup.okhttp3", "okhttp");
//            var last = await repo.GetProjectAsync("org.springframework.boot", "spring-boot-starter-web");

//            var pom = await repo.GetProjectAsync("com.squareup.okhttp3", "okhttp", "3.14.9");

//        }

//        async static Task Test2()
//        {
//            var repo = MavenRepository.FromUrl("http://maven.aliyun.com/repository/central");
//            await repo.Refresh("com.squareup.okhttp3");

//            var groups = repo.Groups;

//        }

//        static void Test3()
//        {
//            var v = "2.3.8.RELEASE";
//            NuGet.Versioning.SemanticVersion.TryParse(v, out var v1);
//            NuGet.Versioning.NuGetVersion.TryParse(v, out var v2);
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

// ФОРМА Авторизации

namespace Kursovaya
{
    public partial class Auth : Form
    {
        int AuthAtt = 0; // количество попыток входа
        private Timer blockTimer = new Timer();
        private int blockSeconds = 10;
        public Auth()
        {
            InitializeComponent();
            TestDataBaseConn();
            EnsurePepeShopJson();
            pwdTextBox.UseSystemPasswordChar = true; // скрываем пароль
            CopyDefaultImagesToAppData(); // метод копирования изображений
            blockTimer.Interval = 1000; // 1 секунда            
            blockTimer.Tick += BlockTimer_Tick;
        }
        public static string EnsurePepeShopJson()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataPath, "pepeShop");
            string filePath = Path.Combine(folderPath, "tables.json");

            // создаём папку, если нет
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // создаём json файл, если нет
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "{}");
            }

            return filePath;
        }
        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            blockSeconds--;

            LogInButton.Text = $"Подождите {blockSeconds} сек.";

            if (blockSeconds <= 0)
            {
                blockTimer.Stop();

                LogInButton.Enabled = true;
                LogInButton.Text = "Войти";

                blockSeconds = 10;
            }
        }
        void CopyDefaultImagesToAppData() // метод копирования изображений по умолчанию из папки приложения в папку appdata
        {
            try // блок обработки исключений
            {
                // формирование пути к папке с изображениями в директории запуска приложения
                string exeImgFolder = Path.Combine(Application.StartupPath, "img");

                // формирование пути к папке для сохранения изображений в папке appdata пользователя
                string appDataImgFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), // получение пути к appdata
                    "pepeShop", // папка приложения в appdata
                    "img" // подпапка для изображений
                );

                // создание директории в appdata, если она не существует (включая все вложенные папки)
                Directory.CreateDirectory(appDataImgFolder);

                // массив имен файлов, которые нужно скопировать
                string[] filesToCopy = { "no-image.png", "gigabyte3060.png",
                    "013dfd30-5717-49b5-b2da-a09195d3d831.jpg",
"02182b27-94b5-49a5-b08d-6817143dc2e3.png",
"02401176-4f13-4e6a-ab12-437201b53ebc.png",
"02a8030f-db38-4348-9009-df990cf81d3a.jpg",
"02ad5e7e-a471-46ad-93dc-79940c15007e.jpg",
"02d79836-baf2-42fa-95bc-5de45663c168.jpg",
"02df6ee0-2bec-4a14-bb99-1e58936300f6.png",
"033c76a0-202f-49c3-8e43-6c2b404a16dc.jpg",
"0353ca68-88fe-4115-8b9d-82fa18c2ea9d.jpg",
"03860b7a-e476-478a-94c5-4f88517d9f20.jpg",
"038e451a-df06-4204-8cc8-4968dd9fa154.jpg",
"03ea4dff-f605-4c3c-9fe9-89ffc658c306.jpg",
"04058f05-9f89-4814-bad3-f6791a9c7455.jpg",
"043559de-6e05-44e6-b958-e3e5d9eeb31d.jpg",
"05e33f3f-dd04-42bb-9e3c-eb96730e8265.jpg",
"06cf694c-04f7-4f05-8fd4-602742ac0ac4.jpg",
"07e3afa1-0d13-4c59-a8c6-1c9bee1ab9ad.jpg",
"0854ed0a-40fd-45e5-b43c-a05e06a15cd9.jpg",
"088e008b-e1c4-4ab8-9aad-937b1194c38e.png",
"08e92840-9194-4894-9915-7a19667d04fd.jpg",
"09c530d3-8c50-4568-9d1a-f28366023a2d.jpg",
"09d17142-a6d3-4001-99c5-9d7a111b3d2c.jpg",
"0abf3f3e-c702-4d74-86a9-47a66aab3816.jpg",
"0b51c17b-baa1-4e77-80c1-45fc9ca2dd8c.jpg",
"0c762237-0f96-4a73-8bea-c4c5bba12ba1.jpg",
"0c87caf1-76ff-499f-986d-d2ec021b4a32.jpg",
"0cb40683-abea-4617-80e2-25d64ec738f4.jpg",
"0cf9b771-b790-4700-9e94-c9fa96524c05.jpg",
"0cfb66e0-7d19-4b62-b3b7-f4ba140ce031.jpg",
"0d0fcc7c-6728-4cb4-8b2b-6427646b4fc3.jpg",
"0d3f0315-5436-4c08-b8e1-2684ca859488.jpg",
"0e641764-e1c5-46a5-9702-b4eededa248f.jpg",
"0eed7268-f4e2-4bc1-9264-b0f332843af8.jpg",
"0f1ec3f8-eb36-4ca2-a271-25afb681c00c.jpg",
"0fd4f668-bd57-49fc-a4eb-7155569a576f.jpg",
"10a98636-1b2c-45b8-a3ff-9d224567f41a.jpg",
"1199b05e-9216-490a-a6db-c8e49ba77f83.jpg",
"121facae-4331-49fd-8308-a56023c212b7.jpg",
"1224be65-ecec-4556-adc7-9e7dd81be657.jpg",
"12412c3c-be9c-424c-a898-c47ba015a27e.jpg",
"125c7829-72b3-460f-8dff-9ba7253eebcd.jpg",
"12c93530-5568-4ce4-8329-2ff66cedb880.png",
"13d8baba-6439-45dd-b862-10b5eaa25b7e.jpg",
"156f4f17-ce6a-4172-9451-9950f2ec1224.jpg",
"15fca06c-df30-4928-b334-b9f3cdcf2e72.jpg",
"17e29c15-acdb-4489-a231-cae8a9979701.jpg",
"17ed4c31-2083-4281-ac17-1ccc9391943b.jpeg",
"17fa9a5a-8898-4330-af83-5520427a9e6c.jpg",
"184aa886-241a-4d9d-b5fd-cf866215e078.jpg",
"1908b75a-bbe5-4387-bf28-5071c9f24bcd.jpg",
"196e836f-25f6-4236-984f-68b2d790571a.jpg",
"1a06c38a-d19e-4105-958a-a1c2e456ec1e.jpg",
"1a2f4401-ba4d-4462-92cf-a588d9a5c55c.jpg",
"1c295ff1-1c11-4d75-a621-c74d1236fe67.jpg",
"1d6f933f-364b-40c3-a1bb-92d1bf6096a1.jpg",
"1d727ac2-7efd-47a7-a44e-a45598653b6b.jpg",
"1ebd7429-fb9a-4c4b-9774-c2c78a3fe14b.jpg",
"1f5ac2fa-c331-4d1a-9d00-906fb7dd1f82.jpg",
"1f84ac08-8623-41ed-b86a-3359e8ab9634.jpg",
"2155dfff-f347-4553-b4fd-029d90cac0cb.jpg",
"242441d1-4d25-44fa-824a-182af6302eee.jpg",
"2495fc99-dbbb-4f89-80cc-b6734c9a186f.jpg",
"24e57f3d-a7d4-4d78-99d0-370f38aa705d.jpg",
"2513919e-6931-4b13-9d08-cee412733a3e.jpg",
"251b4de1-e960-4761-b843-d55d9a2831d3.jpg",
"26059a4d-e618-47b2-ac2e-87c54e799747.jpg",
"26a1a0ef-fce7-4f5c-8a9e-2796cd676dc1.jpg",
"26ff5e94-30e4-4a90-b011-478d5a5b54ce.jpg",
"27438a53-821d-4d03-b0d0-bbbe3c8e4cbf.png",
"277b82ff-3ef1-45af-a1bc-0022e0b96e95.jpeg",
"285a499c-24ef-4e41-aac6-f0dbe34d346f.jpg",
"29c34640-18cd-44e9-b855-95e75698df73.jpg",
"2b01da6d-5226-4bd0-8c4a-6d42c9f6e1a1.jpg",
"2b229353-0900-4cc8-bde0-7a9252b06b39.png",
"2b6b5d35-bda4-4437-9dc8-c6522a80fa73.jpg",
"2ba28e76-104d-4384-a141-858be5b1c602.png",
"2bd2e5fd-6b52-4b55-98ef-b71dc3b669be.jpg",
"2c34646b-f647-4123-bec2-c5c53755faf0.jpg",
"2c3a5eaa-c81e-4207-9581-56bc312833cd.jpg",
"2c65b23e-ebef-4ecd-8f2b-e441748afa03.jpg",
"2d0b1a85-5f92-46b0-a3cd-cee4a375c187.jpg",
"2dc404f9-e3ef-4c0f-9f83-33f666c3832d.jpg",
"2dccf62e-7522-49a8-b361-292c85677843.jpg",
"2e7bae5c-1213-46fc-9a99-f7f12103db84.jpg",
"2ee93c78-6b17-4690-8f39-c0e506cc91f8.png",
"304d6f7d-cd40-4272-8045-fcf11b0108cc.jpg",
"30b636d4-867f-43cd-b2a3-64a545884287.jpg",
"32f2c0bf-00a7-4858-a70c-ebfdb6f8562d.jpg",
"3496a826-81d5-415f-9332-75721320bbd9.jpg",
"3545ff31-8bf4-4422-bdec-9983f109684f.jpg",
"35786a89-a726-40e2-8695-7a8dbf3b22cf.jpg",
"36478460-fff9-4c91-a225-425362ded3bd.jpg",
"379baaa2-a723-4aa7-ab5f-2a66f3dd654b.jpg",
"39244606-5bc6-43cc-aad0-ceb776b7c66d.jpg",
"3925d384-54b4-4b5d-a449-615912397b70.jpg",
"39521787-37be-418b-9438-878f90a19417.png",
"3986206c-f64a-486e-9849-d30c31e6fb70.png",
"3990bcdc-ca86-47d0-a031-fdc3b437ba83.jpg",
"3ab755f0-c3fd-4d1c-abce-e6d00c4739ae.png",
"3b2935da-e617-4c9b-9eb7-b1efee8b78c9.png",
"3e567ee9-a23b-466a-ae49-56643fa86577.jpg",
"3f8193f9-f698-4dce-98d7-9feb57632c56.jpg",
"406a9896-b8f2-4eeb-bbd6-eeb64edbf7af.jpg",
"40ca8ea8-585a-4d0a-907b-39054ff587c5.jpg",
"412d6e33-8bdd-4329-88e0-a613b4291d63.png",
"416ec5f9-1f36-4e14-aa52-99402b1e386b.jpg",
"4171d41a-5f24-4b62-b09b-abfccb6825a5.jpg",
"41cda25b-a5f5-467f-833b-2c66375446ff.jpg",
"425153c6-b6fe-47c2-884f-bc0f8e656226.jpg",
"43162490-4a15-43e0-93fa-5542ae9ce13a.jpeg",
"4326b956-13ad-42f9-b278-3803df2400ad.jpg",
"4350e5b5-8902-47fa-8fb4-6f2af3cec10a.jpg",
"43e8316a-fb29-4357-aa38-a4ba6ed79020.jpg",
"440b4e41-591a-4e63-bdbe-3d2f9bf8e634.jpg",
"454d5b9f-b8b0-477f-9590-328cdfda3a3e.jpg",
"45576348-d5c5-4826-9cf6-50f32efe6e06.jpg",
"459a1607-b388-46f8-afbe-5c2b6727a594.jpg",
"45f25a61-0e0e-426e-b2c0-3ed10f7a470b.jpg",
"464aeb4c-8a30-479c-a681-837d49cf9bce.jpg",
"46a66ecd-240d-4f92-b490-9ce153a841b9.jpg",
"472c2e56-cb34-41cf-94a9-53665b114bf2.jpg",
"4772a0d9-6b72-4f72-b2f5-370a49fe0125.jpg",
"48f4022f-5a3a-4199-a4be-8c04b2e5517d.jpg",
"49915d24-26fd-4114-beee-2c2474514f6e.jpg",
"49dba90d-7aab-4584-a14b-f5a569bfc2f0.jpg",
"4a0cd561-f177-48c5-b3f9-8ba05723bc28.png",
"4a0ec3d7-5812-4f17-8d74-19c2bb357e50.jpg",
"4ab54411-ca4d-48b4-97d5-75589fd14080.jpg",
"4afa2867-820e-4c44-9fd0-867dbcb19595.jpg",
"4b2d7b3c-f090-4477-9625-94a4956260c2.jpg",
"4c895d41-9553-43a5-acda-8e20fd34fd9b.jpg",
"4cf480d6-0145-4537-92d6-10a3015eb27a.jpg",
"4d0a903a-9d17-4618-847a-58bd2ce00529.png",
"4d189d0a-86d8-4b05-8d03-1aa54a53b332.jpg",
"4dc6ce29-1a73-460b-819f-2af8527e59c7.png",
"4df1260e-a278-433f-afde-92cefb783916.jpg",
"4dff63f4-dc16-462b-8d9c-d672f37688bb.jpg",
"4e08703e-2c90-427d-8199-40fd426a02a7.jpg",
"4ebb49cb-e3bc-4295-8617-53ff05ade940.jpg",
"4f193378-94b1-4f16-9e72-bfb2708354bc.jpg",
"4f577a8b-b8cc-482e-94b2-46d671218060.jpg",
"4f7d2e2b-9c7d-4005-9da6-36bb45510787.jpg",
"4fca3545-037c-46e0-9acd-0dcc7f28a903.jpg",
"500e4814-3c7a-4402-ae03-3ad2c03d9aa1.jpg",
"5040deae-ed15-4d12-abe3-df0b5f118daf.jpg",
"510816ce-1bce-444c-a115-d79e154573ee.jpg",
"51f138a0-c006-4274-af8b-6201da9af41a.png",
"523c5ec4-9bd7-42c5-8586-66a406124dec.jpg",
"52425a72-af64-45a7-adcc-7327f87a6b30.jpg",
"534275bc-460f-4c38-8fb0-b422ca22ede9.png",
"534f77c2-00f8-476e-9f59-1ebcad527d7e.jpg",
"54732b1e-996b-44fb-8903-eed7f8746c66.jpg",
"54d6762d-a433-40aa-93bb-9fcf0ae09b2b.jpg",
"554dbcea-f27f-4462-9847-c9a4a3563c1f.jpg",
"56af6399-f189-44b9-93ee-41e5f6b5bc6a.jpg",
"573ae400-7f90-4c15-bfc4-114ea4a4333d.jpg",
"573f0818-9dec-4631-8f84-a32d749c37fc.jpg",
"5791a1d0-1a07-41f1-a01a-207647de926d.jpg",
"580803ea-f297-4d8e-ba7d-12d958aa692e.png",
"590c86aa-9e78-4044-a768-c214a9e1313f.jpg",
"59bef808-9c5f-4b4a-b259-bcf71f4e47d2.jpg",
"5acaaaa5-db6a-48a8-86d8-40239637a057.jpg",
"5b57f6f3-7ba9-4193-a023-59b050e97a7f.jpg",
"5b8df801-8b0a-4ca8-8b54-3336f85d4bd0.jpg",
"5c952f17-30ea-4366-94f9-cc647f22d518.jpg",
"5dcfa7c7-99b4-4bd6-818b-cda4d216af7d.jpg",
"5e255c7c-16ac-46cb-8672-33fd29bb6ab9.jpg",
"5eaf4207-a000-418c-9733-21065319d576.png",
"5f1a8e9a-3cc8-4408-872c-4b832ba8ede9.png",
"5fc79793-386b-4ccd-aa92-dd6c72755303.jpg",
"60e9e988-5f61-4b84-8a2e-db5d902ca1e7.png",
"61349a7b-e55c-4232-b12f-f50fdd630f9c.jpg",
"61f21e7e-9d6a-4d8e-8f46-0d93edf6b49a.jpg",
"62308db8-439e-443d-9b8e-683111adeb62.jpg",
"629e3bc5-123a-4a95-8e1b-76db2ae7a2a9.jpg",
"62c42c87-62aa-4189-bacb-00aa36c77e0a.jpg",
"661b77fe-8180-4424-b87e-c896f2958b12.jpg",
"6754713f-1d1b-4474-9359-3c2fc2a634bc.png",
"67666ca9-137e-4e07-88f9-2297d751d9eb.png",
"6964d822-8a65-4ec2-bf66-c8c16c31e81e.jpg",
"69ffbaa6-619a-4975-b26a-a6ea3d5ee9d7.jpg",
"6c2962a0-6010-448c-89c6-00cc2c7b72a3.jpg",
"6cee49d7-be23-4d63-9cc2-9e2b30d67385.jpg",
"6e5e17ea-13ed-4dc8-b80f-5ff2d947afc9.jpg",
"6ecf07ed-a3af-4f00-9b3e-195e9c73fbf5.jpg",
"703f4990-96e2-4865-a0ad-6ebef0335a73.jpg",
"7046505c-3e53-4b23-924f-eb8105385f89.png",
"70d9de2f-b9ab-4db5-abb6-7b714ff73795.jpg",
"71cc9bc6-f0e6-4e69-9027-b095c4fc83b1.jpg",
"726f3d4c-66a5-4d30-a7c6-4140b6c27807.jpg",
"729f96d1-c009-4ffd-8ed0-842e6756b2a3.jpg",
"72f91f6f-1624-4c5b-9a2f-c39f5a7c7705.jpg",
"741281f1-9b4c-4c2e-8cae-2de95b4fa63f.png",
"75854b6f-d56c-45f8-beac-e6ebaaa2ae10.jpg",
"7693f528-85ef-4695-bf85-9d6d124dfdc4.jpg",
"76b7a7c4-1da0-4cae-a621-0f6c8c122203.jpg",
"7763d6ec-c31d-42eb-ba65-558ba24c6e89.jpg",
"77826ddd-a5d6-44d1-b3ee-05bfd0631ef3.jpg",
"79295735-a915-4de4-9e47-aee62f2f6904.jpg",
"799471bb-94c8-4132-af49-a36489ee4004.jpg",
"79b6849b-e668-40fd-a5c5-10a5cf30e073.jpg",
"7a487d98-01e6-4a82-b17f-4045b6958b9a.jpg",
"7a4de824-9bb1-46cb-b623-0845ad18fb71.png",
"7a9159c7-e387-4688-af1e-8e42c386e849.jpg",
"7aa2be9d-75a8-4cef-96ff-be17a4e4aa0b.jpg",
"7ac75326-0aeb-4e77-8e13-1205a4d07051.png",
"7b3da5bf-a026-4236-bb84-50989d1dd6e2.jpg",
"7b58daf5-ebe3-44bc-8ff1-51e4bc276cc6.jpg",
"7b5e3d12-ded2-429f-9a32-d272030a4e58.jpg",
"7cc35a1e-cd84-4e95-98a9-aa53078e2b4e.jpg",
"7e3f0cf9-16e7-48dd-9e02-426adb1eb26d.jpg",
"7e749229-d9f8-435e-9bab-31913b12c9ce.jpg",
"7ed31d0e-2c6b-4063-b1be-3aaeb8ba0c19.jpg",
"7f06306d-7a20-46d1-9004-90a00d0b6e02.jpg",
"7f0cb99d-e124-4c4e-80a4-9c0023635485.png",
"7f7b864b-a1b3-4060-a3b3-8a98c0eb7615.png",
"7f9b2ce1-2c33-4ffe-aa7c-9214e423f8b1.jpg",
"80b7ff1e-9dbd-47d3-bc67-7319cf7a3b41.jpg",
"8211e643-61d6-458d-9f5e-46440e98301a.png",
"828bee39-3422-41c1-b710-8515546ffabc.jpg",
"8292895b-78ad-45c4-adfe-364053e6c3be.jpg",
"829a2e59-dd86-46c9-a5ff-b04905cd34c4.jpg",
"82d5f11d-cba9-4ae4-9b4c-1ad6023df64e.jpg",
"82db1ef1-c93f-461c-9266-306484d51b88.jpg",
"83e59933-66c8-43f8-b488-d91eef6852d6.jpg",
"84ac05db-b930-4d88-a309-f57560f3e783.jpg",
"85e357b9-157b-4696-92ad-c208f5b99730.jpg",
"86c4717c-8f8a-4b86-8274-9a28f70e38e3.jpg",
"86c4d255-48b3-487c-a360-7f7b4b3a8270.jpg",
"8822769d-f336-48fd-b86f-c940f780c1bd.jpg",
"8905300e-64cc-4374-af9d-c2bf2964d31e.jpg",
"890cd3e9-56b8-4cd3-8001-af448b89963c.jpg",
"8934c230-72a0-4ce0-b3aa-c754beb21248.jpeg",
"8942cbfd-fbfe-418f-a861-28d00efec482.jpg",
"899b404a-7177-4e17-aace-b9170cfe2497.png",
"8a3abba4-94bd-47fe-9944-26817db332e5.jpg",
"8a9f0689-807d-498b-bbd9-4438630a9e92.jpg",
"8b172470-e38a-4a24-bb42-90f31abb7598.jpg",
"8bafc7d4-a48b-403f-be5d-57bb57d6ca8d.jpg",
"8c783181-03d1-48fe-aae2-eb04223cdec7.jpg",
"8c8366f0-4bb2-48ed-ac2e-81435a22e1c4.jpg",
"8d3751dc-e177-40cf-b8ba-e1693a5670c3.jpg",
"8dec5fc5-f5e8-496c-981b-3d738d6a0bf2.jpg",
"8e8199a6-5e9a-451b-b097-2efe0eb81be5.jpg",
"8f077490-62e9-4109-9c92-c5a8fe70a6e8.jpg",
"8f35f067-aa17-4053-b7c9-d6f83c934b00.png",
"8f60480f-79be-4480-a77e-77ab069aec3e.jpg",
"8f66c22f-fa14-4262-b35c-df37d8ea32ba.jpg",
"8fbef24c-36c4-48ae-9a4a-8c0a8ff5e16d.jpg",
"9032e623-3c0a-4826-bf0a-e0e8bb81b94a.jpg",
"909e44ab-5166-4769-97de-25dd86b2e077.jpg",
"90d9ac5e-0a5f-4452-9cd7-a3eed50cea64.jpg",
"9173236d-29ea-4aec-a7d2-3d599735653c.jpg",
"925a2ba2-3a13-424f-ab5e-f399870f4608.jpg",
"926fe18e-ec4c-4353-9718-0b044ea23ec1.jpg",
"9386ac50-849e-46d9-8c06-f3decf86b938.png",
"93cfa0e7-64ed-48f2-aa85-5e6a40fa4244.jpg",
"940b1910-5b2a-449f-987b-1e6102fc41c3.jpg",
"94ac72fe-6f21-42f5-ac87-f38c39e8997f.jpg",
"94cbb010-47d3-4714-b3f3-747ad637294f.jpg",
"94cfe319-0be0-4d9d-a774-3f01fb4e4a92.jpg",
"95ebaa2b-cd7d-4465-a93d-ed69b61a3198.jpg",
"96ba91e8-a756-4656-8578-dd780aaad4b3.jpg",
"96f9e68d-3394-40c9-90bc-9ef46b39b326.png",
"9858efa3-e6ac-4294-be7c-e42d71bf4919.jpg",
"99f3ce07-0a00-4b53-8421-41b2ae3fd442.jpg",
"9a0eec23-7f21-4a4a-811d-10f33867792a.jpg",
"9a9b9074-a80a-4f55-b80c-fd30a5a49b18.jpg",
"9b0162d1-faa9-404a-a199-35f90bb72bbe.jpg",
"9ba5561c-9b44-44c1-a114-0d41acf45dcb.jpg",
"9d38d4ef-dd40-4e40-835a-40cbc903929f.jpg",
"9ecea31c-7406-4252-9894-53ca105db623.jpg",
"a0579f8d-c6f1-49b0-8c69-1daedfb74731.jpg",
"a1f5ec5c-5f37-4047-b7f0-f2b2e16bd355.jpg",
"a26f3f8a-ed68-47ae-9a93-7c01cc083948.jpg",
"a300c7cc-043f-4f73-ba89-f3ea0e69533c.jpg",
"a3ee7d57-7f49-4dec-9f38-567a134f4a88.jpg",
"a5e98695-e337-4800-bf73-f3b43d95e5a9.png",
"a67b5186-3ea2-4c3f-8cd4-fff93e8576e7.jpg",
"a72634f3-1bee-4f0b-b67d-d6b9a5527592.jpg",
"a76bb4c5-49b9-4e8b-90c1-32b0cd601615.jpg",
"a8db8715-077d-4a41-8622-1c8923ed3f49.jpg",
"a8e190a5-11f5-4530-bbaf-65eaaef499fa.jpg",
"a92e6774-97db-482a-975c-0227928c3341.jpg",
"a96b10e1-a90e-4392-b60f-d01d1c3d319e.jpg",
"a97e1447-0fa2-43e7-9e10-4f54e7da3b8d.jpg",
"a9aac13f-dde8-4441-b181-9e03c9ee159d.jpg",
"aa36bacb-7483-4866-9790-700c626bfce1.jpg",
"aaa19b17-f643-41c4-8419-7e38ed3abc85.jpg",
"ab5fa530-817d-4228-a565-818cb59ed6de.jpg",
"ab9e7acd-ade1-48ad-bc9a-05b816dc83a7.jpg",
"acc81701-df32-4345-a946-0f915b79c181.jpg",
"acebd105-25d3-49b2-8583-83cc6befa820.jpg",
"ad66a25b-4082-4621-9c73-78a69d90ca60.jpg",
"ae3cfc7f-df35-4b7b-a5c2-c6e42a7fe223.jpg",
"aeac9706-3ecf-4a17-a409-b64b29f9e484.jpg",
"aeec38f8-80a5-4331-9edc-8fdf4724df88.jpg",
"af97ca16-d1df-4cab-bcfe-d12da76ae5a0.jpg",
"b46f82d3-611e-4f88-b58a-4986c8fb8ccf.png",
"b4d5e5a1-e0f4-4b69-8db6-35c423aef040.jpg",
"b5cf2526-d7cf-49ba-bc3f-1e646f48d3f5.jpg",
"b6e92e02-8dad-4b3c-8138-02f47926c9f5.jpg",
"b79a5d12-b626-48bf-8735-12bddc5061b5.jpg",
"b7e07d60-e5eb-4829-9213-638b65f3cf82.png",
"b8d76109-2f13-4223-a7bb-1f584cd4ca0d.jpg",
"b9c6eca1-d844-4c9e-aba0-fed1588772ee.jpg",
"ba0528b3-4adf-462e-a5e6-60b1ae35fa7b.jpg",
"ba256331-cea8-4790-b7ab-f428824f06c8.jpg",
"bc264107-4277-474e-815f-0a92c74f72e4.jpg",
"bc9af00d-ad59-46e1-b289-c0df1ea832b3.jpg",
"bcad8373-724d-47af-94de-3210c46e4704.jpg",
"bd3e649d-f53a-47c1-8757-4e9dc185be8d.jpg",
"bdb8e04f-56d5-4b3e-aee7-9818b5b88ca5.jpg",
"bea24d4e-5c66-4c0e-af33-29018e93156d.jpg",
"bee6ef72-bcee-4d42-a1b0-40dc8074d527.jpg",
"bf4121d7-f881-4a35-bc39-263ba0e8afb5.jpg",
"bf845aa1-4496-461d-b666-70e20ec1abb2.jpg",
"c0e64589-1138-4a20-af03-428a952a5d1d.jpg",
"c19e0748-8c6d-43ab-90fb-ccfe3a1592ec.png",
"c3830b84-e44a-48d7-b6e4-ee75c1082f7f.jpg",
"c4212cfa-1fee-4598-8d3c-f3b3cc7575a6.jpg",
"c4471513-5549-4b07-bb03-2345039cb82d.jpg",
"c4508652-3ff5-48dc-8d65-82cfb52545e2.jpg",
"c49cf2f8-2870-4bed-9b36-fff162af1ff7.jpg",
"c5c84b93-16c4-405b-ba0b-fe5ce5fb8dfe.jpg",
"c73ecfe9-11ad-4fae-a338-a48777e77b93.jpg",
"c8c87fba-5c75-4b58-bd38-7fe527982f1d.jpg",
"c8cc85b0-bc1a-402b-bccc-6b8066de908f.jpg",
"c8ec1ad8-9dcb-4364-a854-4e0d2d054422.jpg",
"c9a7ad41-6e37-428d-ab95-82edb3355664.jpg",
"c9e48842-ae1b-4e52-a64c-27a3be781ab0.jpg",
"ca38dff2-9521-417f-b155-cc621473cf52.jpg",
"ca9d9557-4f9f-4938-a87a-121f9e3cbca7.jpg",
"cb5cfd49-552f-4ca4-972a-58b4938ed2c4.png",
"cce3b6b0-891f-42f8-8860-7aae3b0f9256.jpg",
"cd5f3f33-5c43-4bf9-826a-d966dde38eab.jpg",
"cd916d08-c45c-4393-9501-59d6110e2921.jpg",
"cdcc6e4e-7d78-4cf4-814d-9af6668782c1.png",
"d0caa1f2-773b-4dea-9d70-6c43de25385a.png",
"d153b697-16d7-4c1f-88f5-daa8c021d523.jpg",
"d2e45ac5-f929-4413-ad8e-392ab24604b7.jpg",
"d2e671f3-a6d2-4b57-835d-879b5b1a389c.jpg",
"d30fccbf-a111-417a-8b61-bb9ce195a2b1.jpg",
"d321c07d-9b00-4634-a08e-ec935e8fc609.jpg",
"d3a0eaf0-0ec1-4dcc-91ee-972d85d90a82.jpg",
"d589cd75-4ed2-43a9-92bc-184cccd2db3b.jpg",
"d64c8025-aa1b-420a-ba4b-331fe9c5356f.jpg",
"d6648b87-3fde-449a-b968-b9e6ebb65037.jpg",
"d6b095e6-61dc-4294-a661-0dfe245ef11a.jpg",
"d6ff09fa-8760-4572-bcfe-935153e213a6.jpg",
"d74f4eed-8017-4421-a483-69c766e53f36.jpg",
"d7bf48a5-1d91-482d-a348-2fa606af2c7c.jpg",
"d81503ae-d504-49ea-ba6e-ef4d331ef8d3.jpg",
"d93265e9-ce89-4a20-bfbb-3bcae9c9a3d0.png",
"daad4d11-54c6-4a13-8412-06fa3bc892aa.jpg",
"dabc8703-5a84-4e18-9102-3d78900e0cba.jpg",
"dadf0cb6-4f57-4441-94c9-36a7346a4de8.png",
"db739ce6-ac04-4795-9c7b-9316cf168974.jpg",
"db7e1a19-d9b6-4e82-ab73-6d34dab72561.png",
"de20b06d-467f-4fa4-90c7-0948c65e9d9e.jpg",
"df826a8b-47b3-4fea-8fc8-3b7bc6e39a8a.jpg",
"df897d86-86ee-456d-92e6-f9f38c7a3031.jpg",
"e0f437bc-d53e-44ec-a217-25406c3e8eaf.jpg",
"e18162bd-f83b-4946-abbc-7cd48778c6f9.jpg",
"e1a527f3-e719-4435-ad6d-38d13d444184.jpg",
"e20954f8-3797-4dfe-b0b9-7d083e762f98.jpg",
"e212ecca-9fdc-4f3d-b568-09fd0c7be5fc.jpg",
"e2a1d884-8f75-476a-a4c5-230de20614ea.png",
"e2dd73ed-5397-4275-afd8-ebcec41b5fa6.jpg",
"e363ed6e-facc-46d2-85c4-7b7770eb4d97.png",
"e4c9075f-8f5a-4061-a81c-ae5c3dc4d810.jpg",
"e518287d-cbae-4079-b7b7-0f3b4964209e.jpg",
"e5ebe4db-ba6a-45c5-88e7-11c86441d596.jpg",
"e721e4fa-fdbc-4fc9-8429-1472b255132f.jpg",
"e72435db-bf20-4a4e-b54f-872a63e4dc40.jpg",
"e7a8661c-13dc-451d-9f01-6703845ea23c.jpeg",
"e7b0af1b-f5a9-4d2d-ba7f-d6d9f996ec2b.jpg",
"e8840faf-4fd5-4348-87fc-36dfb19d53b2.jpg",
"e8cb4dae-9a1d-4e9d-9496-929e672b4ee7.jpg",
"e921354c-61ea-40ba-8449-f9755c18b3d4.jpg",
"e95e2812-800c-49a3-9804-8d5406c84299.jpg",
"e9d1a9c1-9870-4ebe-9bef-5b9837b8982e.jpg",
"eb21968d-9685-4233-b0ab-887bd9cacc07.jpg",
"ec29b98b-41ae-41c8-aa9d-e65503bbf030.jpg",
"ed0c7971-ba99-4e6b-858e-e5364a19a744.jpg",
"ed13adab-0d59-42a8-8213-473c6e05f9cd.jpg",
"ed504aff-a656-42b4-a77a-d917f65307c5.jpg",
"ed63cae4-10e9-462e-b879-e64e80e16fda.jpg",
"ee7ef93b-d408-4eee-b1ba-b58bc8065bbc.jpg",
"ee97d7a5-1553-4ef2-988f-412bf253c203.jpg",
"efa2fb31-1785-4b88-8557-227b02f6936f.jpg",
"f08a7714-e183-473b-bb99-2f92634d47b2.jpg",
"f18111cc-bdce-4ecc-98e3-22c65ef9fa31.jpg",
"f1a10640-8233-405f-985e-635ee6a907f0.jpg",
"f1f086bb-31ab-434f-b989-eda030e164e0.jpg",
"f251ef1b-a4ec-4a68-8f7c-a0a921403616.jpg",
"f2e9dc33-b46e-4feb-a438-98b331313c4f.jpg",
"f3fb4b5a-c51e-4773-bf5f-bb2ca349a1ce.jpg",
"f5492f9a-6ba4-4303-96fe-9d87d52bd178.jpg",
"f56b3d39-db03-45ee-b6b8-636cb510b722.jpg",
"f5decd06-0a31-4b96-9628-3accb918ad0b.png",
"f6ff3241-3081-4738-bc6f-84a341e9dd46.jpg",
"f72efe79-26e6-4c1c-aaae-66775fb7ece3.jpg",
"f7959174-3b3b-4565-80c4-0d897ebe1ebc.jpeg",
"f7bcce50-2919-4530-ac6e-ba5e0061a72e.png",
"f7c662e5-f6f2-4879-b3b5-0fc84b31ae94.jpg",
"f8e16a87-fe55-41d8-b733-707f73801fb5.jpg",
"f979cb5f-3cb1-4030-a0d9-0e4920a31c3e.jpg",
"f9a90964-43ce-4d36-b614-df25bd427a90.jpg",
"fa4220aa-9fc5-4bf7-851d-99a7d772542f.jpg",
"fa4362b8-0659-4964-9f67-fb81ba8c869c.jpg",
"fa64c375-7356-4a7a-9d1e-2a7b141c8ba7.jpg",
"fb62b025-e042-40d9-8a15-311451455bf9.jpg",
"fd8fed64-c09c-4d15-b17e-5be6bec74689.jpg",
"fdd85979-bc8e-450f-a8ec-13fe987a1aeb.jpg",
"fdf1800b-179e-40d7-99b1-52ee69544e0f.jpg",};

                // перебор всех файлов из массива
                foreach (string fileName in filesToCopy)
                {
                    // полный путь к исходному файлу в папке приложения
                    string sourcePath = Path.Combine(exeImgFolder, fileName);

                    // полный путь к целевому файлу в папке appdata
                    string destPath = Path.Combine(appDataImgFolder, fileName);

                    // проверка: существует ли исходный файл и нет ли уже такого файла в appdata
                    if (File.Exists(sourcePath) && !File.Exists(destPath))
                    {
                        // копирование файла из папки приложения в папку appdata
                        File.Copy(sourcePath, destPath);
                    }
                }
            }
            catch (Exception e) // перехват любого исключения
            {
                MessageBox.Show(e.Message); // вывод сообщения об ошибке пользователю
            }
        }
        bool inCaptcha = false; // булева должен ли пользователь ввести капчу для входа
        // обработчик на надатие кнопки "Войти"
        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "admin" && pwdTextBox.Text == "admin") // проверка на "вшитого админа"
            {
                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                Administrator.AdminMenu menu = new Administrator.AdminMenu(); // создаём экземпляр класса меню администратора
                Hide(); // скрываем форму авторизации
                menu.ShowDialog();  // отображаем меню
                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                loginTextBox.Text = ""; // затираем данные для входа
                pwdTextBox.Text = "";
            }
            getUserID(); // получаем айди пользователя по введённым данным
            if (AuthAtt >= 1 && !inCaptcha) // если была не успешная попытка входа то при слудующем нужно ввести капчу
            {
                this.Height = 530; // расширяем окно чтобы показать капчу
                inCaptcha = true; // булева должен ли пользователь ввести капчу для входа
            }
            if (inCaptcha) // если нужно решение капчи
            {
                if (CaptchaTextBox.Text.Trim() == captchaAnewer) // проверяем корректность капчи
                {
                    inCaptcha = false;
                    CheckUser(); // проверяем пользователя
                    this.Height = 350; // уменьшаем форму если капча решена правильно
                }
                else
                {
                    MessageBox.Show("Капча введена не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                    Captcha(); loginTextBox.Text = ""; // генерируем новую капчу и затираем введённые данные для входа
                    pwdTextBox.Text = "";

                    LogInButton.Enabled = false; // блокируем кнопку
                    blockTimer.Start(); // запускаем таймер
                }
            }
            else 
            {
                if (loginTextBox.Text.Length > 3 && pwdTextBox.Text.Length > 3) // Проверка длинны пароля
                {
                    CheckUser(); // проверяем пользователя
                }
                else
                {
                    MessageBox.Show("Логин или пароль слишком короткие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                    loginTextBox.Text = ""; // затираем введённые данные для входа
                    pwdTextBox.Text = "";
                }
            }
        }
        private void getUserID() // получение айди пользователя
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // инициируем подключение 
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand($"SELECT id from staff where login = '{loginTextBox.Text.Trim()}';", conn); // выполняем запрос
                    int user_id = Convert.ToInt32(cmd.ExecuteScalar()); // получаем ответ и записываем его в переменную
                    user.Default.userID = user_id; // сохраняем айди для дальнейшей работы 
                }
            }
            catch(Exception ex) { MessageBox.Show($"Ошибка {ex.Message}"); }
        } 
        private void CheckUser() // функция проверки пользователя
        {
            string query = $"SELECT password FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос для получения хэш пароля по логину
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // инициируем подключение 
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand(query, conn); // выполняем запрос
                    object pwd_db = cmd.ExecuteScalar(); // записываем в переменную
                    if (pwd_db == null)  // проверяем что хэш пароль не пустой
                    {
                        MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                        AuthAtt++; loginTextBox.Text = "";  // засчитываем попытку входа и затираем данные для входа
                        pwdTextBox.Text = "";
                        Captcha();  // отображаем капчу
                        this.Height = 530; // расширяем форму для отображения капчи
                    }
                    else
                    {
                        string actual_pwd = GetHashPwd(pwdTextBox.Text);  // вычисляем хэш пароль из того пароля которы ввёл пользователь
                        if (pwd_db.ToString() == actual_pwd)  // сравниваем хэш от того пароля сто ввёл пользователь с тем что хранится в БД
                        {
                            int role = GetUserRole();  // плучаем роль пользователя
                            if (role == 1) // если пользователь имеет роль "Пользователь"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                User.UserMenu menu = new User.UserMenu(); // создаём экземпляр класса меню пользователя
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog(); // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                            else if(role == 2) // если пользователь имеет роль "Товаровед"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                ProdExpert.ExpertMenu menu = new ProdExpert.ExpertMenu(); // создаём экземпляр класса меню товароведа
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog(); // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                            else if(role == 3) // если пользователь имеет роль "Администратор"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                Administrator.AdminMenu menu = new Administrator.AdminMenu(); // создаём экземпляр класса меню администратора
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog();  // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомляем о неверных данных для входа
                            loginTextBox.Text = ""; // затираем данные для входа
                            pwdTextBox.Text = "";
                            AuthAtt++; // засчитываем попытку входа
                            this.Height = 530; // расширяем форму для отображения капчи
                            Captcha();  // отображаем капчу
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = "";} // обработка ошибок
        }



        private string GetHashPwd(string pwd) // функция принимает строку пароль вычисляет и возвращает хэш строку 
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd); // получаем массив байтов
                byte[] hash = sha256.ComputeHash(bytes); // получаем байтовый массив хэша

                StringBuilder result = new StringBuilder(); // собираем байты в строку
                foreach (byte b in hash) // перебираме все байты
                {
                    result.Append(b.ToString("x2")); // записываем в строку
                }
                return result.ToString(); // возвращаем хэш строку
            }
        }



        int captchaId = 4; // айди капчи которая отобразится
        int i = 0;  // дополнительная временная переменная для хранения айди капчи
        string captchaAnewer = ""; // строка хранения ответа на капчу
        private void Captcha()  // отображение капчи
        {            
            Random r = new Random(); // экземпляр класса рандома
            captchaId = r.Next(1, 4); // генерируем айди 
            while (true) // цикл генерации чтобы капча не повторялась
            {
                if (captchaId == i)
                {
                    captchaId = r.Next(1, 4); // генерируем айди 
                }
                else
                {
                    break;
                }
            }            
            i = captchaId; // сохраняем новый айди капчи 
            if (captchaId == 1) // если айди капчи 1 то отображаем изображение 1
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/1.png"); // отображаем изображение
                captchaAnewer = "hP%4"; // ответ на капчу
            }
            else if (captchaId == 2) // если айди капчи 2 то отображаем изображение 2
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/2.png"); // отображаем изображение
                captchaAnewer = "%9RR"; // ответ на капчу
            }
            else if (captchaId == 3) // если айди капчи 3 то отображаем изображение 3
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/3.png"); // отображаем изображение
                captchaAnewer = "52$V"; // ответ на капчу
            }
        }

        private void ReCaptcha_Click(object sender, EventArgs e) // обработчик кнопки перегенерации капчи
        {
            Captcha();
            CaptchaTextBox.Text = "";
        }


        private int GetUserRole() // функция получения роли пользователя
        {
            string query = $"SELECT role FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // подключение
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand(query, conn); // выполняем запрос
                    if (cmd.ExecuteScalar() == null) // если роль отсутствует пропускаем
                    {
                        
                    }
                    else
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar()); // если роль есть то возвращаем её айди
                    }
                }                
            }
            catch (Exception EX) // обработка ошибок
            {
                MessageBox.Show($"{EX.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = ""; // перезатираем введённые данные
            }
            return 0; // если ранее ничего не вернули возвращаем 0
        }

        private void TestDataBaseConn() // проверка подключения к БД
        {            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString()))
                {
                    conn.Open(); // инициируем подключение к базе данных
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    EditConn ed = new EditConn(); 
                    ed.ShowDialog(); // если подлючение не произошло вызываем форму настроцки подключения
                }
            }
                
        }

        private void connedit_Click(object sender, EventArgs e)
        {
            EditConn ec = new EditConn();
            ec.ShowDialog();
        }        

        private void ShowPwdButton_Click(object sender, EventArgs e) // отображаем или скрываем пароль
        {
            pwdTextBox.UseSystemPasswordChar = !pwdTextBox.UseSystemPasswordChar;
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

# راه پیام (MessageWay)

یک راهکار جامع پیام‌رسانی برای دات‌نت (.NET)، شامل یک کلاینت قدرتمند برای API راه پیام (MsgWay API).

[![Build](https://github.com/Torabi-srh/MessageWay/actions/workflows/ci.yml/badge.svg)](https://github.com/Torabi-srh/MessageWay/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/MessageWay.svg)](https://www.nuget.org/packages/MessageWay)

## مقدمه

راه پیام (MessageWay) روشی منعطف و قابل توسعه برای مدیریت پیام‌رسانی در برنامه‌های دات‌نت شما فراهم می‌کند. این کتابخانه شامل یک کلاینت کاملاً تایپ‌شده (Typed Client) برای تعامل با [MsgWay API](https://api.msgway.com) است.

برای اطلاعات بیشتر می‌توانید به وب‌سایت رسمی و گیت‌هاب ما مراجعه کنید:
- **وب‌سایت:** [https://msgway.com/](https://msgway.com/)
- **گیت‌هاب:** [https://github.com/MessageWay](https://github.com/MessageWay)

## شروع کار

### نصب

بسته را از طریق NuGet نصب کنید:

```bash
dotnet add package MessageWay
```

### نحوه استفاده

#### تزریق وابستگی (پیشنهادی)

سرویس‌های MsgWay را در فایل `Startup.cs` یا `Program.cs` ثبت کنید:

```csharp
using MessageWay;

builder.Services.AddMsgWay(options =>
{
    options.ApiKey = "YOUR_API_KEY";
    options.Language = "fa"; // اختیاری، پیش‌فرض "fa" است
});
```

رابط `IMsgWayClient` را به سرویس‌های خود تزریق کنید:

```csharp
public class MyService
{
    private readonly IMsgWayClient _client;

    public MyService(IMsgWayClient client)
    {
        _client = client;
    }

    public async Task SendOtpAsync(string mobile)
    {
        var request = new SendRequest
        {
            Mobile = mobile,
            Method = SendMethod.Sms,
            TemplateId = 3 // شناسه الگوی OTP شما
        };

        var response = await _client.SendAsync(request);
        
        if (response.Status == "success")
        {
            Console.WriteLine($"پیام ارسال شد! شناسه مرجع: {response.ReferenceId}");
        }
    }
}
```

#### نمونه‌سازی دستی

اگر از تزریق وابستگی (DI) استفاده نمی‌کنید، می‌توانید کلاینت را مستقیماً نمونه‌سازی کنید:

```csharp
var httpClient = new HttpClient();
var options = new MsgWayOptions { ApiKey = "YOUR_API_KEY" };
var client = new MsgWayClient(httpClient, options);
```

### ویژگی‌ها

- **ارسال پیام (Send Messages)**: پشتیبانی از پیامک (SMS)، تماس صوتی (IVR) و پیام‌رسان گپ.
- **بررسی وضعیت (Check Status)**: استعلام وضعیت پیام‌های ارسال شده.
- **تایید کد یکبار مصرف (Verify OTP)**: پشتیبانی داخلی برای تایید کدهای OTP.
- **دریافت موجودی (Get Balance)**: بررسی موجودی حساب.
- **دریافت الگوها (Get Templates)**: دریافت جزئیات الگوها.

## ساختار

- **MessageWay.Core**: انتزاعات اصلی، رابط‌ها و مدل‌ها.
- **MessageWay**: پیاده‌سازی اصلی و نقطه ورود.
- **MessageWay.Tests**: تست‌های واحد (Unit Tests).

## مشارکت

از درخواست‌های پول (Pull Requests) استقبال می‌شود. برای تغییرات عمده، لطفاً ابتدا یک issue باز کنید تا در مورد آنچه می‌خواهید تغییر دهید بحث کنیم.

## مجوز

[MIT](LICENSE)

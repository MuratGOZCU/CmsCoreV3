using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Setting:BaseEntity
    {
        //INDEX
        public string HeaderString { get; set; }
        public string GoogleAnalytics { get; set; }
        public string FooterScript { get; set; }
        [StringLength(200)]
        public string MapTitle { get; set; }
        [StringLength(200)]
        public string MapLat { get; set; }
        [StringLength(200)]
        public string MapLon { get; set; }
        //MAIL
        [StringLength(200)]
        [Display(Name = "Smtp Kullanıcı Adı")]
        public string SmtpUserName { get; set; }
        [StringLength(200)]
        [Display(Name = "Smtp Şifresi")]
        public string SmtpPassword { get; set; }
        [StringLength(200)]
        public string SmtpHost { get; set; }
        [StringLength(200)]
        public string SmtpPort { get; set; }
        public bool SmtpUseSSL { get; set; }
        //E-STORE
        [Display(Name = "Vergilendirmeyi ve vergi hesaplamalarını etkinleştir")]
        public bool EnableTaxes { get; set; }
        [Display(Name = "Site genelinde mağaza duyuru metnini etkinleştir")]
        public bool EnableStoreAnnouncement { get; set; }
        [Display(Name = "Para Birimi")]
        public long? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        [Display(Name = "Para Birimi")]
        public Currency Currency { get; set; }
        [Display(Name = "Ürün incelemelerini etkinleştir")]
        public bool EnableProductReviews { get; set; }
        [Display(Name = "Müşteri incelemelerinde doğrulanmış kullanıcı etiketini göster")]
        public bool ShowVerifiedUserLabelInCustomerReviews { get; set; }
        [Display(Name = "İncelemeler yalnızca doğrulanmış kullanıcılar tarafından bırakılabilir")]
        public bool ReviewsCanOnlyBeReleasedByVerifiedUsers { get; set; }
        [Display(Name = "İncelemelerde yıldız derecelendirmesini etkinleştir")]
        public bool EnableStarRatingInReviews { get; set; }
        [Display(Name = "Yıldız derecelendirmeleri gerekli olmalıdır, isteğe bağlı değil")]
        public bool StarRatingsAreRequired { get; set; }
        [Display(Name = "Mağaza Sayfası")]
        public long? StorePageId { get; set; }
        [ForeignKey("StorePageId")]
        [Display(Name = "Mağaza Sayfası")]
        public Page StorePage { get; set; }
        [Display(Name = "Sepete ekledikten sonra yönlendir")]
        public bool RedirectAfterAddingBasket { get; set; }
        [Display(Name ="Kırp")]
        public bool CropImage { get; set; }
        [Display(Name = "Resim Yüksekliği")]
        public int ImageHeight { get; set; }
        [Display(Name = "Resim Genişliği")]
        public int ImageWidth { get; set; }
        [Display(Name = "Stok yönetimini etkinleştir")]
        public bool EnableStockManagement { get; set; }
        [Display(Name ="Stoğu Tut (Dakika)")]
        public int WaitStock { get; set; }
        [Display(Name = "Düşük stok bildirimlerini etkinleştir")]
        public bool EnableLowStockNotifications { get; set; }
        [Display(Name = "Stokta yok bildirimlerini etkinleştir")]
        public bool EnableOutOfStockNotifications { get; set; }
        [Display(Name ="Bildirim Alıcıları")]
        public string NotificationReceivers { get; set; }
        [Display(Name ="Düşük stok eşiği")]
        public int LowStockThreshold { get; set; }
        [Display(Name = "Stok tükenme eşiği")]
        public int StockExhaustThreshold { get; set; }
        [Display(Name = "Stokları biten ürünleri gizle")]
        public bool HideOutOfStockProducts { get; set; }
        [Display(Name = "İndirmeler için giriş yapılmalı")]
        public bool LoginRequiredForDownloads { get; set; }
        [Display(Name = "Ödeme yapıldıktan sonra indirilebilir ürünlere erişim izni ver")]
        public bool AllowAccessToDownloadableProductsAfterPaymentIsGranted { get; set; }
        [Display(Name = "Vergiyle girilmiş fiyatlar")]
        public bool PricesIncludeTax { get; set; }
        [Display(Name = "Her satırda yuvarlama yerine ara toplam düzeyinde vergiyi yuvarla")]
        public bool TaxRoundAtSubTotal { get; set; }
        [StringLength(200)]
        [Display(Name ="Ek vergi sınıfları")]
        public string AdditionalTaxClasses { get; set; }
        [StringLength(200)]
        [Display(Name = "Fiyat görüntüleme ön eki")]
        public string PriceDisplayFrontPart { get; set; }
        [StringLength(200)]
        [Display(Name = "Bölge adı")]
        public string ShippingRegion { get; set; }
        [Display(Name = "Hata ayıklama modunu etkinleştir")]
        public bool EnableDebugMode { get; set; }
        [Display(Name = "Kupon kullanımını etkinleştir")]
        public bool EnableCoupons { get; set; }
        [Display(Name = "Kupon indirimlerini sırayla hesapla")]
        public bool CalculateCouponDiscountInOrder { get; set; }
        [Display(Name = "Misafir siparişini etkinleştir")]
        public bool EnableGuestPayment { get; set; }
        [Display(Name = "Güvenli ödemeye zorla")]
        public bool ForceSecurePayment { get; set; }
        [Display(Name = "Ödeme işleminden ayrılırken HTTP'ye zorla")]
        public bool ForceHttpAfterPayment { get; set; }
        [Display(Name = "Sepet Sayfası")]
        public long? BasketPageId { get; set; }
        [ForeignKey("BasketPageId")]
        [Display(Name = "Sepet Sayfası")]
        public Page BasketPage { get; set; }
        [Display(Name = "Ödeme Sayfası")]
        public long? PaymentPageId { get; set; }
        [ForeignKey("PaymentPageId")]
        [Display(Name = "Ödeme Sayfası")]
        public Page PaymentPage { get; set; }
        [Display(Name = "Şartlar ve Koşullar Sayfası")]
        public long? TermsAndConditionsPageId { get; set; }
        [ForeignKey("TermsAndConditionsPageId")]
        [Display(Name = "Şartlar ve Koşullar Sayfası")]
        public Page TermsAndConditionsPage { get; set; }
        [StringLength(200)]
        [Display(Name = "Ödeme")]
        public string PaymentSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Sipariş alındı")]
        public string OrderReceivedSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Ödeme yöntemi ekle")]
        public string AddPaymentMethodSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Ödeme yöntemini sil")]
        public string DeletePaymentMethodSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Varsayılan ödeme yöntemini belirle")]
        public string SetDefaultPaymentMethodSlug { get; set; }
        [Display(Name = "Hesabım Sayfası")]
        public long? MyAccountPageId { get; set; }
        [ForeignKey("MyAccountPageId")]
        [Display(Name = "Hesabım Sayfası")]
        public Page MyAccountPage { get; set; }
        [Display(Name = "Ödeme sayfasında üye kaydını etkinleştir.")]
        public bool EnableMemberRegistrationOnThePaymentPage { get; set; }
        [Display(Name = "Hesabım sayfasında üye kaydını etkinleştir.")]
        public bool EnableMemberRegistrationOnTheMyAccountPage { get; set; }
        [Display(Name = "Ödeme sayfasında müşteri girişi hatırlamasını göster")]
        public bool ShowRememberMeOnPaymentLogin { get; set; }
        [Display(Name = "Müşteri e-postasından otomatik olarak kullanıcı adı oluştur.")]
        public bool AutomaticallyCreateAUsernameFromTheCustomerEmail { get; set; }
        [Display(Name = "Otomatik müşteri şifresi oluştur")]
        public bool CreateAutomaticCustomerPassword { get; set; }
        [StringLength(200)]
        [Display(Name = "Siparişler")]
        public string OrderSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Siparişi görüntüle")]
        public string ViewOrderSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "indirmeler")]
        public string DownloadSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Hesabı düzenle")]
        public string EditAccountSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string AddressSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Ödeme yöntemleri")]
        public string PaymentMethodsSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Şifremi unuttum")]
        public string ForgotPasswordSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Çıkış")]
        public string LogoutSlug { get; set; }
        [StringLength(200)]
        [Display(Name = "Gönderen Adı")]
        public string SenderName { get; set; }
        [StringLength(200)]
        [Display(Name = "Gönderen Email Adresi")]
        public string SenderEmail { get; set; }
        [StringLength(200)]
        [Display(Name = "Üst kısım görseli")]
        public string UpperVisual { get; set; }
        [Display(Name = "Alt kısım metni")]
        public string BottomText { get; set; }
        [StringLength(200)]
        [Display(Name = "Temel renk")]
        public string BaseColor { get; set; }
        [StringLength(200)]
        [Display(Name = "Arka plan rengi")]
        public string BackgroundColor { get; set; }
        [StringLength(200)]
        [Display(Name = "Gövde arka plan rengi")]
        public string BodyBackgroundColor { get; set; }
        [StringLength(200)]
        [Display(Name = "Gövde metin rengi")]
        public string BodyTextColor { get; set; }
        [Display(Name = "REST API etkinleştir")]
        public bool EnableRestApi { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kullanıcı")]
        public long? ApiUserId { get; set; }
        [ForeignKey("ApiUserId")]
        [Display(Name ="Kullanıcı")]
        public ApplicationUser ApiUser { get; set; }
    }
}

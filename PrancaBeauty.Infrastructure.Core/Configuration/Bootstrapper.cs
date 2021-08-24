﻿using Framework.Application.Services.Email;
using Framework.Application.Services.FTP;
using Framework.Application.Services.IpList;
using Framework.Application.Services.Security.AntiShell;
using Framework.Application.Services.Sms;
using Framework.Common.Utilities.Download;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrancaBeauty.Application.Apps.Accesslevel;
using PrancaBeauty.Application.Apps.AccesslevelsRoles;
using PrancaBeauty.Application.Apps.Address;
using PrancaBeauty.Application.Apps.Categories;
using PrancaBeauty.Application.Apps.Cities;
using PrancaBeauty.Application.Apps.Countries;
using PrancaBeauty.Application.Apps.File;
using PrancaBeauty.Application.Apps.FileServer;
using PrancaBeauty.Application.Apps.Keywords;
using PrancaBeauty.Application.Apps.KeywordsProducts;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.Application.Apps.ProductAsk;
using PrancaBeauty.Application.Apps.ProductAskLikes;
using PrancaBeauty.Application.Apps.ProductMedia;
using PrancaBeauty.Application.Apps.ProductPrices;
using PrancaBeauty.Application.Apps.ProductPropertiesValues;
using PrancaBeauty.Application.Apps.ProductPropertis;
using PrancaBeauty.Application.Apps.ProductReviews;
using PrancaBeauty.Application.Apps.ProductReviewsAttribute;
using PrancaBeauty.Application.Apps.ProductReviewsAttributeValues;
using PrancaBeauty.Application.Apps.ProductReviewsLike;
using PrancaBeauty.Application.Apps.ProductReviewsMedia;
using PrancaBeauty.Application.Apps.Products;
using PrancaBeauty.Application.Apps.ProductSellers;
using PrancaBeauty.Application.Apps.ProductTopic;
using PrancaBeauty.Application.Apps.ProductVariantItems;
using PrancaBeauty.Application.Apps.ProductVariants;
using PrancaBeauty.Application.Apps.Province;
using PrancaBeauty.Application.Apps.Role;
using PrancaBeauty.Application.Apps.Setting;
using PrancaBeauty.Application.Apps.Template;
using PrancaBeauty.Application.Apps.Users;
using PrancaBeauty.Application.Common.FtpWapper;
using PrancaBeauty.Domain.Category.CategoriyAgg.Contracts;
using PrancaBeauty.Domain.FileServer.FileAgg.Contracts;
using PrancaBeauty.Domain.FileServer.ServerAgg.Contracts;
using PrancaBeauty.Domain.Keywords.KeywordAgg.Contracts;
using PrancaBeauty.Domain.Keywords.Keywords_Products.Contracts;
using PrancaBeauty.Domain.Product.ProductAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductAskAgg.Contarcts;
using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductMediaAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPricesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPropertiesValuesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsAttributeValuesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsLikesAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductReviewsMediaAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductSellerAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductTopicAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductVariantAgg.Contracts;
using PrancaBeauty.Domain.Product.ProductVariantItemsAgg.Contracts;
using PrancaBeauty.Domain.Region.CityAgg.Contracts;
using PrancaBeauty.Domain.Region.CountryAgg.Contracts;
using PrancaBeauty.Domain.Region.LanguageAgg.Contracts;
using PrancaBeauty.Domain.Region.ProvinceAgg.Contracts;
using PrancaBeauty.Domain.Setting.SettingAgg.Contracts;
using PrancaBeauty.Domain.Template.TemplateAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AddressAgg.Contracts;
using PrancaBeauty.Domain.User.RoleAgg.Contracts;
using PrancaBeauty.Domain.User.SellerAgg.Contracts;
using PrancaBeauty.Domain.User.UserAgg.Contracts;
using PrancaBeauty.Infrastructure.EfCore.Context;
using PrancaBeauty.Infrastructure.EfCore.Repository.AccessLevel;
using PrancaBeauty.Infrastructure.EfCore.Repository.FileServer;
using PrancaBeauty.Infrastructure.EfCore.Repository.Region;
using PrancaBeauty.Infrastructure.EfCore.Repository.Role;
using PrancaBeauty.Infrastructure.EfCore.Repository.Setting;
using PrancaBeauty.Infrastructure.EfCore.Repository.Template;
using PrancaBeauty.Infrastructure.EfCore.Repository.User;
using PrancaBeauty.Infrastructure.EFCore.Repository.Address;
using PrancaBeauty.Infrastructure.EFCore.Repository.Categories;
using PrancaBeauty.Infrastructure.EFCore.Repository.Cities;
using PrancaBeauty.Infrastructure.EFCore.Repository.Counties;
using PrancaBeauty.Infrastructure.EFCore.Repository.Keywords;
using PrancaBeauty.Infrastructure.EFCore.Repository.Keywords_Products;
using PrancaBeauty.Infrastructure.EFCore.Repository.Product;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductAsk;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductAskLikes;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductMedia;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductPrices;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductProperties;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductPropertiesValues;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviews;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttribute;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttribute_Translate;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsAttributeValues;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsLike;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductReviewsMedia;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductSellers;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductTopic;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductVariantItems;
using PrancaBeauty.Infrastructure.EFCore.Repository.ProductVariants;
using PrancaBeauty.Infrastructure.EFCore.Repository.Province;
using PrancaBeauty.Infrastructure.EFCore.Repository.Sellers;
using PrancaBeauty.Infrastructure.Logger.SeriLogger;

namespace PrancaBeauty.Infrastructure.Core.Configuration
{
    public static class Bootstrapper
    {
        public static void Config(this IServiceCollection services)
        {
            //services.AddDbContext<MainContext>(opt =>
            //    opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));

            //services.AddScoped<ILogger, Serilogger>();
            //services.AddScoped<IUserRepository, UserRepository>();


            services.AddDbContext<MainContext>(opt => opt.UseSqlServer("Server=.;Database=PrancaBeautyDb;Trusted_Connection=True;"));

            services.AddScoped<ILogger, Serilogger>();
            services.AddScoped<IEmailSender, GmailSender>();
            services.AddScoped<IDownloader, Downloader>();
            services.AddScoped<ISmsSender, KaveNegarSmsSender>();
            services.AddScoped<IIpList, IPList>();
            services.AddScoped<IFtpClient, FtpClient>();
            services.AddScoped<IFtpWapper, FtpWapper>();
            services.AddScoped<IAniShell, AniShell>();


            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IAccessLevelRepository, AccessLevelRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IFileServerRepository, FileServerRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IAccesslevelRolesRepository, AccesslevelRolesRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategory_TranslateRepository, Category_TranslateRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<IKeywords_ProductsRepository, Keywords_ProductsRepository>();
            services.AddScoped<IProductPricesRepository, ProductPricesRepository>();
            services.AddScoped<IProductMediaRepository, ProductMediaRepository>();
            services.AddScoped<IProductReviewsRepository, ProductReviewsRepository>();
            services.AddScoped<IProductReviewsLikeRepository, ProductReviewsLikeRepository>();
            services.AddScoped<IProductAskRepository, ProductAskRepository>();
            services.AddScoped<IProductAskLikesRepository, ProductAskLikesRepository>();
            services.AddScoped<IProductReviewsMediaRepository, ProductReviewsMediaRepository>();
            services.AddScoped<IProductTopicRepository, ProductTopicRepository>();
            services.AddScoped<IProductTopic_TranslatesRepository, ProductTopic_TranslatesRepository>();
            services.AddScoped<IProductPropertisRepository, ProductPropertisRepository>();
            services.AddScoped<IProductPropertisRepository, ProductPropertisRepository>();
            services.AddScoped<IProductPropertiesValuesRepository, ProductPropertiesValuesRepository>();
            services.AddScoped<IProductVariantsRepository, ProductVariantsRepository>();
            services.AddScoped<IProductVariants_TranslatesRepository, ProductVariants_TranslatesRepository>();
            services.AddScoped<IProductVariantItemsRepository, ProductVariantItemsRepository>();
            services.AddScoped<IProductSellersRepsoitory, ProductSellersRepsoitory>();
            services.AddScoped<ISellersRepository, SellersRepository>();
            services.AddScoped<ISeller_TranslatesRepository, Seller_TranslatesRepository>();
            services.AddScoped<IProductReviewsAttributeRepository, ProductReviewsAttributeRepository>();
            services.AddScoped<IProductReviewsAttribute_TranslateRepository, ProductReviewsAttribute_TranslateRepository>();
            services.AddScoped<IProductReviewsAttributeValuesRepository, ProductReviewsAttributeValuesRepository>();

            // Applications
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ITemplateApplication, TemplateApplication>();
            services.AddScoped<ISettingApplication, SettingApplication>();
            services.AddScoped<IAccesslevelApplication, AccesslevelApplication>();
            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddScoped<ILanguageApplication, LanguageApplication>();
            services.AddScoped<IFileApplication, FileApplication>();
            services.AddScoped<IFileServerApplication, FileServerApplication>();
            services.AddScoped<IAccesslevelRolesApplication, AccesslevelRolesApplication>();
            services.AddScoped<IAddressApplication, AddressApplication>();
            services.AddScoped<ICityApplication, CityApplication>();
            services.AddScoped<ICountryApplication, CountryApplication>();
            services.AddScoped<IProvinceApplication, ProvinceApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<IKeywordApplication, KeywordApplication>();
            services.AddScoped<IKeywordProductsApplication, KeywordProductsApplication>();
            services.AddScoped<IProductPriceApplication, ProductPriceApplication>();
            services.AddScoped<IProductMediaApplication, ProductMediaApplication>();
            services.AddScoped<IProductReviewsApplication, ProductReviewsApplication>();
            services.AddScoped<IProductReviewsLikeApplication, ProductReviewsLikeApplication>();
            services.AddScoped<IProductAskApplication, ProductAskApplication>();
            services.AddScoped<IProductAskLikesApplication, ProductAskLikesApplication>();
            services.AddScoped<IProductReviewsMediaApplication, ProductReviewsMediaApplication>();
            services.AddScoped<IProductTopicApplication, ProductTopicApplication>();
            services.AddScoped<IProductPropertisApplication, ProductPropertisApplication>();
            services.AddScoped<IProductPropertiesValuesApplication, ProductPropertiesValuesApplication>();
            services.AddScoped<IProductVariantsApplication, ProductVariantsApplication>();
            services.AddScoped<IProductVariantItemsApplication, ProductVariantItemsApplication>();
            services.AddScoped<IProductSellersApplication, ProductSellersApplication>();
            services.AddScoped<IProductReviewsAttributeApplication, ProductReviewsAttributeApplication>();
            services.AddScoped<IProductReviewsAttributeValuesApplication, ProductReviewsAttributeValuesApplication>();

        }
    }
}

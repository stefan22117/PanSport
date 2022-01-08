using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PanSport.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PanSport.Models
{
    [NotMapped]
    public class CartItem
    {

        private void SetImagePath(PanSportDbContext context, SubProduct subProduct)
        {
            string path = "/images/";

            if (subProduct == null)
            {
                path += "noimage.png";
            }
            else
            {
                SubProduct sp = context.SubProducts
                    .Include(x => x.Product.Category)
                    .FirstOrDefault(x => x.Id == subProduct.Id);
                if (sp == null)
                {
                    path += "noimage.png";
                }
                else
                {
                    this.SubProductLink = "/proizvodi" + "/" + sp?.Product?.Category?.Slug
                        + "/" + sp?.Product?.Slug;

                    path += sp?.Product?.Category?.Slug
                            + "/" + sp?.Product?.Slug + "/" + sp.Image;
                }
            }

            this.Image = path;
        }
        public CartItem()
        {

        }
        public CartItem(PanSportDbContext context, SubProduct subProduct)
        {
            SetImagePath(context, subProduct);


            this.Title = subProduct?.Product?.Title;

            subProduct.Product = null;

            this.SubProductId = subProduct.Id;
            this.SubProduct = subProduct;

        }

        public CartItem(PanSportDbContext context, OrderItem orderItem)
        {
            SetImagePath(context, orderItem.SubProduct);


            this.Title = orderItem.SubProduct?.Product?.Title;

            orderItem.SubProduct.Product = null;

            this.SubProductId = orderItem.SubProductId;
            this.SubProduct = orderItem.SubProduct;

            this.Amount = orderItem.Amount;

        }


        public int Id { get; set; }
        public int SubProductId { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string SubProductLink { get; set; }


        [ForeignKey("SubProductId")]
        public virtual SubProduct SubProduct { get; set; }
    }
}

﻿using AutoMapper;
using Teknoroma.Application.Features.Suppliers.Command.Create;
using Teknoroma.Application.Features.Suppliers.Command.Update;
using Teknoroma.Application.Features.Suppliers.Models;
using Teknoroma.Application.Features.Suppliers.Queries.GetById;
using Teknoroma.Application.Features.Suppliers.Queries.GetList;
using Teknoroma.Domain.Entities;

namespace Teknoroma.Application.Features.Suppliers.Profiles
{
	public class MapperProfile:Profile
	{
        public MapperProfile()
        {
            CreateMap<Supplier, CreateSupplierCommandRequest>().ReverseMap();
            CreateMap<Supplier,UpdateSupplierCommandRequest>().ReverseMap();
            CreateMap<Supplier, GetByIdSupplierQueryResponse>().ReverseMap();
            CreateMap<Supplier,GetAllSupplierQueryResponse>().ReverseMap();

            CreateMap<CreateSupplierViewModel, CreateSupplierCommandRequest>().ReverseMap();
            CreateMap<SupplierViewModel, UpdateSupplierCommandRequest>().ReverseMap();
            CreateMap<SupplierViewModel, GetByIdSupplierQueryResponse>().ReverseMap();
            CreateMap<SupplierViewModel,GetAllSupplierQueryResponse>().ReverseMap();
        }
    }
}
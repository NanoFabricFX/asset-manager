﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class LicensesController : Controller
    {
        private readonly IAsyncRepository<License> _licenseasyncRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Manufacturer> _menurepository;
        private readonly IAsyncRepository<Depreciation> _depreciationrepository;
        public readonly IAsyncRepository<Supplier> _supplierasyncRepository;

        public LicensesController(
            IAsyncRepository<Company> companyRepository,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<License> licenseasyncRepository,
            IAsyncRepository<Manufacturer> manufacturer,
            IAsyncRepository<Depreciation> deprepos,
            IAsyncRepository<Supplier> supplierRepository
            )
        {
            this._companyRepository = companyRepository;
            this._categoryRepository = categoryRepository;
            this._licenseasyncRepository = licenseasyncRepository;
            this._menurepository = manufacturer;
            this._depreciationrepository = deprepos;
            this._supplierasyncRepository = supplierRepository;
        }
        public async Task<IActionResult> Index()
        {
            var licenseslist = await _licenseasyncRepository.ListAllAsync();
            return View(licenseslist);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyRepository.ListAllAsync();
            ViewBag.Categorylist = await _categoryRepository.ListAllAsync();
            ViewBag.Manufacturers = await _menurepository.ListAllAsync();
            ViewBag.Depreciations = await _depreciationrepository.ListAllAsync();
            ViewBag.Suppliers = await _supplierasyncRepository.ListAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(License licenses)
        {
            licenses.Depreciate = true;
            if (ModelState.IsValid)
            {
                await _licenseasyncRepository.AddAsync(licenses);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using MVCProject.Repositories.Interfaces;
using MVCProject.Repositories.Classes;
using MVCProject.Entities;
using MVCProject.ViewModels;

namespace MVCProject.Controllers;

public class PlanController : Controller
{
    //private readonly IPlanRepositoty _planRepository = new PlanRepository();
    //private GymDbContext dbcontext = new GymDbContext();
    //public IActionResult IndexTest()
    //{
    //    return View();
    //}
    private readonly IPlanRepositoty _planRepository;
    private readonly IMembershipRepository _membershipRepository;

    public PlanController(IPlanRepositoty planRepository, IMembershipRepository membershipRepository)
    {
        _planRepository = planRepository;
        _membershipRepository = membershipRepository;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var plans = await _planRepository.GetAllAsync();
       var planViewModels = plans.Select(p => new ViewModels.PlanViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            DurationDays = p.DurationDays,
            IsActive = p.IsActive
        }).ToList();
        return View(planViewModels);

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken ct)
    {
        var plan = await _planRepository.GetByIdAsync(id);
        if (plan is null || !plan.IsActive)
        {
            TempData["ErrorMessage"] = "This plan can not be edited.";
            return RedirectToAction(nameof(Index));
        }
        var hascurrentMembership = await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);
        if (hascurrentMembership)
        {
            TempData["ErrorMessage"] = "This plan can not be edited.";
            return RedirectToAction(nameof(Index));
        }
        var PlanViewModel = new UpdatePlanViewModel()
        {
            PlanName = plan.Name,
            Description = plan.Description,
            DurationDays = plan.DurationDays,
            Price = plan.Price





        };
        return View(PlanViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int id, UpdatePlanViewModel Updatedplan, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return View(Updatedplan);
        }

        var plan = await _planRepository.GetByIdAsync(id, ct);
        if (plan is null || !plan.IsActive)
        {
            TempData["ErrorMessage"] = "This plan can not be edited.";
            return RedirectToAction(nameof(Index));
        }
        var hascurrentMembership = await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);
        if (hascurrentMembership)
        {
            TempData["ErrorMessage"] = "This plan can not be edited.";
            return RedirectToAction(nameof(Index));
        }

        plan.Price = Updatedplan.Price;
        plan.DurationDays = Updatedplan.DurationDays;
        plan.Description = Updatedplan.Description;
        plan.UpdatedAt = DateTime.Now;

        var result = await _planRepository.UpdateAsync(ct) > 0;
        if (result)
        {
            TempData["SuccessMessage"] = "Plan updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Plan failed to update.");
            return View(Updatedplan);
        }
    }
}


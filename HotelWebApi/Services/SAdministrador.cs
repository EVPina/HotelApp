using AutoMapper;
using HotelWebApi.Interfaces;
using HotelWebApi.Models;
using HotelWebApi.ViewModel;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Services
{
    public class SAdministrador : ISAdministrador
    {
        private readonly AppDBContext _context;
        private readonly ILogger<SAdministrador> _logger;
        private readonly IMapper _mapper;

        public SAdministrador(ILogger<SAdministrador> logger, AppDBContext context,IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public  async Task<string> ActualizarSucursal(VMSucursal vMSucursal)
        {
            string response = "Sucursal actualizo correctamente.";

            _logger.LogInformation("Iniciando el proceso de actualizar sucursal.");

            try
            {
                Sucursales sucursales = await _context.Sucursales.FirstOrDefaultAsync(x => x.Codigo_Sucursal == vMSucursal.Codigo_Sucursal);

                if (sucursales == null)
                {
                    _logger.LogWarning("Sucursal no encontrada con el código: {Codigo_Sucursal}", vMSucursal.Codigo_Sucursal);
                    return "Sucursal no encontrada.";
                }
                else
                {

                    if (!string.IsNullOrEmpty(vMSucursal.Nombre_Sucursal))
                    {
                        sucursales.Nombre_Sucursal = vMSucursal.Nombre_Sucursal;
                    }

                    if (!string.IsNullOrEmpty(vMSucursal.Direccion_Sucursal))
                    {
                        sucursales.Direccion_Sucursal = vMSucursal.Direccion_Sucursal;
                    }

                    if (!string.IsNullOrEmpty(vMSucursal.Telefono_Sucursal))
                    {
                        sucursales.Telefono_Sucursal = vMSucursal.Telefono_Sucursal;
                    }

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Sucursal actualizada correctamente: {Nombre_Sucursal}", vMSucursal.Nombre_Sucursal);
                }
            }
            catch(Exception err)
            {
                _logger.LogError("Error al actualizar la sucursal: {ErrorMessage}", err.Message);
                response = "Error en la actualizacion";
            }

            return response;
        }
    }
}

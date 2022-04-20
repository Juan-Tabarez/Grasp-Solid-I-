//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        /// <summary>
        /// Para asignar esta responsabilidad utilizamos el metodo Expert ya que 
        /// la clase Recipe es la que tiene la información de los steps necesaria
        /// la cual es necesaria para cumplir con la responsabilidad que se pide.
        /// Asumí que es más optimo de este modo ya que el atributo steps el cual 
        /// contiene todos los "step", es privado, por lo tanto para que se pueda 
        /// utilizar en otra clase se deberia agregar un metodo get.
        /// </summary>
        /// <returns></returns>
        public double GetProductionCost()
        {
            double costoInsumos = 0;

            double costoEquipamiento = 0;    

            double costoTotal = 0;

            foreach (Step step in this.steps)
            {
                costoInsumos += step.Input.UnitCost * step.Quantity;

                costoEquipamiento += step.Time * step.Equipment.HourlyCost;
            }

            costoTotal = costoEquipamiento + costoInsumos;
            
            return Math.Round(costoTotal);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}" + $" y su costo total es de {GetProductionCost()}");
            }
        }
    }
}
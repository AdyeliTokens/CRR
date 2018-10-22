namespace CRR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CRR.Models.Entidades;
    using CRR.Models.Entidades.Specs;
    using CRR.Models.Entidades.Admin;

    internal sealed class Configuration : DbMigrationsConfiguration<CRR.DAL.CRRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CRR.DAL.CRRContext";
        }

        protected override void Seed(CRR.DAL.CRRContext context)
        {
            //  This method will be called after migrating to the latest version.
            var brands = new List<Brand>
            {
                new Brand {CodeFA = "FA068810.01", Description = "CHESTERFIELDBLUE(4.0)KS",CigaretteCode = "7B7VW", CigaretteWeight=0.000818, TobaccoWeight=0.000629, CigaretteCost = 0.06894387, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA065992.02", Description = "MARLBORO(RED2.5)LSBOX20",CigaretteCode = "7AXYN", CigaretteWeight=0.000788, TobaccoWeight=0.000608, CigaretteCost = 0.08507672, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA069025.01", Description = "CHESTERFIELDORIGINAL(4.0)KS",CigaretteCode = "7BAHQ", CigaretteWeight=0.000845, TobaccoWeight=0.000697, CigaretteCost = 0.07149173, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA024711.16", Description = "DALTONKSBOX20",CigaretteCode = "7AFHX", CigaretteWeight=0.000818, TobaccoWeight=0.000669, CigaretteCost = 0.05924631, VeinCode="V0O5K", Active = true},
                new Brand {CodeFA = "FA024712.16", Description = "RODEOKSBOX20",CigaretteCode = "7AFHX", CigaretteWeight=0.000818, TobaccoWeight=0.000669, CigaretteCost = 0.05924631, VeinCode="V0O5K", Active = true},
                new Brand {CodeFA = "FA035313.15", Description = "BARONET[.]KS[.]",CigaretteCode = "7AFHX", CigaretteWeight=0.000818, TobaccoWeight=0.000669, CigaretteCost = 0.05924631, VeinCode="V0O5K", Active = true},
                new Brand {CodeFA = "FA065997.00", Description = "MARLBOROGOLD(2.5)KS",CigaretteCode = "7AYLN", CigaretteWeight=0.000818, TobaccoWeight=0.000669, CigaretteCost = 0.07815105, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA066959.00", Description = "MARLBOROBLUEICEMentholKS",CigaretteCode = "7AXVL", CigaretteWeight=0.000828, TobaccoWeight=0.000608, CigaretteCost = 0.12949901, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA062533.02", Description = "MARLBOROGOLDORIGINALKS",CigaretteCode = "7B7MT", CigaretteWeight=0.000832, TobaccoWeight=0.000609, CigaretteCost = 0.0944869, VeinCode="V0C83", Active = true},
                new Brand {CodeFA = "FA062735.00", Description = "L&MFASTFORWARDPURPLEMentho",CigaretteCode = "7AWHM", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.13164595, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA062733.01", Description = "DERBYMENTOLCAPSMentholKS",CigaretteCode = "7AUPD", CigaretteWeight=0.000866, TobaccoWeight=0.000646, CigaretteCost = 0.12955603, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA041176.02", Description = "L&MFASTFORWARDMentholKS[.",CigaretteCode = "7AFLO", CigaretteWeight=0.000871, TobaccoWeight=0.000651, CigaretteCost = 0.12681626, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA068864.01", Description = "CHESTERFIELDMINT(4.0)Mentho",CigaretteCode = "7B7VX", CigaretteWeight=0.000849, TobaccoWeight=0.000645, CigaretteCost = 0.07837758, VeinCode="V0O5L", Active = true},
                new Brand {CodeFA = "FA069024.01", Description = "CHESTERFIELDORIGINAL(4.0)KS",CigaretteCode = "7BAHQ", CigaretteWeight=0.000845, TobaccoWeight=0.000697, CigaretteCost = 0.07149173, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA065994.00", Description = "MARLBORO(RED2.5)RSBOX20",CigaretteCode = "7AYGH", CigaretteWeight=0.000708, TobaccoWeight=0.000525, CigaretteCost = 0.07785899, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA068155.02", Description = "DELICADOSFRESCOSMentholLS",CigaretteCode = "7AZCZ", CigaretteWeight=0.000822, TobaccoWeight=0.000673, CigaretteCost = 0.08403496, VeinCode="V0O5L", Active = true},
                new Brand {CodeFA = "FA065943.04", Description = "DELICADOSORIGINALESLS",CigaretteCode = "7B7UH", CigaretteWeight=0.000798, TobaccoWeight=0.000651, CigaretteCost = 0.06888881, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA068154.00", Description = "DELICADOSCLAROSLS",CigaretteCode = "7AZDS", CigaretteWeight=0.000807, TobaccoWeight=0.000651, CigaretteCost = 0.06928991, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA069038.01", Description = "CHESTERFIELDREMIXPURPLE(4.0",CigaretteCode = "7B7VZ", CigaretteWeight=0.000985, TobaccoWeight=0.000771, CigaretteCost = 0.14395441, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA069037.01", Description = "CHESTERFIELDREMIXSINGLEFTF",CigaretteCode = "7B7VY", CigaretteWeight=0.00104, TobaccoWeight=0.000822, CigaretteCost = 0.13663465, VeinCode="V0O5L", Active = true},
                new Brand {CodeFA = "FA043178.02", Description = "DIPLOMATMenthol100",CigaretteCode = "7B7NS", CigaretteWeight=0.001045, TobaccoWeight=0.000862, CigaretteCost = 0.09879416, VeinCode="V0C85", Active = true},
                new Brand {CodeFA = "FA065913.02", Description = "MARLBORODOUBLEFUSIONRUBY(",CigaretteCode = "7AZJJ", CigaretteWeight=0.001035, TobaccoWeight=0.000767, CigaretteCost = 0.18775444, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA065991.00", Description = "MARLBORO(RED2.5)KSSOF20",CigaretteCode = "7AXYM", CigaretteWeight=0.000829, TobaccoWeight=0.000649, CigaretteCost = 0.08439776, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA066043.00", Description = "MARLBOROGOLD(2.5)100RCB20",CigaretteCode = "7AYDG", CigaretteWeight=0.000971, TobaccoWeight=0.000757, CigaretteCost = 0.13086949, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA069832.00", Description = "MARLBORO(RED2.5)100BOX20",CigaretteCode = "7AVJD", CigaretteWeight=0.00097, TobaccoWeight=0.000756, CigaretteCost = 0.14790539, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA063062.03", Description = "BENSON&HEDGESCRYSTALVIOLET",CigaretteCode = "7AUYI", CigaretteWeight=0.000814, TobaccoWeight=0.00061, CigaretteCost = 0.12917927, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA054619.16", Description = "DELICADOSORIGINALESLS",CigaretteCode = "7B7UH", CigaretteWeight=0.000798, TobaccoWeight=0.000651, CigaretteCost = 0.06888881, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA021253.23", Description = "BENSON&HEDGESGOLD100",CigaretteCode = "7AZZV", CigaretteWeight=0.001007, TobaccoWeight=0.00082, CigaretteCost = 0.09996664, VeinCode="V0P8V", Active = true},
                new Brand {CodeFA = "FA050313.07", Description = "DELICADOSOVALADOSNFSLIRSO",CigaretteCode = "7ALCZ", CigaretteWeight=0.000729, TobaccoWeight=0.000729, CigaretteCost = 0.05818084, VeinCode="V0L5W", Active = true},
                new Brand {CodeFA = "FA044087.01", Description = "MARLBOROGOLDORIGINALKSBOX10",CigaretteCode = "7B7MS", CigaretteWeight=0.000798, TobaccoWeight=0.000609, CigaretteCost = 0.09261448, VeinCode="V0C83", Active = true},
                new Brand {CodeFA = "FA068057.00", Description = "L&M(RED)MNTKSBOX10",CigaretteCode = "7AZTC", CigaretteWeight=0.000866, TobaccoWeight=0.00065, CigaretteCost = 0.1251632, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA065896.00", Description = "L&MFORWARDKSBOX10",CigaretteCode = "7AFLC", CigaretteWeight=0.000861, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA030988.01", Description = "VIRGINIAS.MentholSLI100",CigaretteCode = "7AWRC", CigaretteWeight=0.000837, TobaccoWeight=0.000598, CigaretteCost = 0.11648708, VeinCode="V0P3X", Active = true},
                new Brand {CodeFA = "FA058665.00", Description = "MARLBOROFUSIONBLASTMenthol",CigaretteCode = "7AQPH", CigaretteWeight=0.000872, TobaccoWeight=0.000605, CigaretteCost = 0.17238231, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA066072.00", Description = "MARLBORODBLFUPURMNTKSBOX20",CigaretteCode = "7AQPH", CigaretteWeight=0.000872, TobaccoWeight=0.000605, CigaretteCost = 0.17238231, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA066647.00", Description = "MARLBORODOUBLEFUSIONPURPLEKSBOX20",CigaretteCode = "7AXUF", CigaretteWeight=0.000873, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA066648.00", Description = "MARLBORODBLFUPURMNTKSBOX20",CigaretteCode = "7AXUF", CigaretteWeight=0.000873, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066649.00", Description = "MARLBORODBLFUPURMNTKSBOX20",CigaretteCode = "7AXUF", CigaretteWeight=0.000873, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="", Active = true},
                new Brand {CodeFA = "FA065943.05", Description = "DELICADOSORIGINALESLS",CigaretteCode = "7B7UH", CigaretteWeight=0.000798, TobaccoWeight=0.000651, CigaretteCost = 0.06888881, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA068650.00", Description = "MARLBOROGOLD(2.5)100BOX14",CigaretteCode = "7AYDG", CigaretteWeight=0.00097, TobaccoWeight=0.000757, CigaretteCost = 0.13086949, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA066062.02", Description = "MARLBOROICEXPME2MNT100BOX14",CigaretteCode = "7AVAD", CigaretteWeight=0.000999, TobaccoWeight=0.000773, CigaretteCost = 0.1772851, VeinCode="V0L5Y", Active = true},
                new Brand {CodeFA = "FA069844.01", Description = "MARLBOROGOLD(2.5)100RCB20",CigaretteCode = "7AYDG", CigaretteWeight=0.00097, TobaccoWeight=0.000757, CigaretteCost = 0.13086949, VeinCode="", Active = true},
                new Brand {CodeFA = "FA055877.10", Description = "BENSON&HEDGESGOLDPEARL100RCB20",CigaretteCode = "7AYTP", CigaretteWeight=0.001032, TobaccoWeight=0.000818, CigaretteCost = 0.14337738, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059079.10", Description = "BENSON&HEDGESMENTHOLPMNT100RCB20",CigaretteCode = "7ATVP", CigaretteWeight=0.000985, TobaccoWeight=0.000771, CigaretteCost = 0.14120366, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA065914.03", Description = "MARLBOROD-FUSIONAMBER(2.5)100BOX20",CigaretteCode = "7AZJK", CigaretteWeight=0.001022, TobaccoWeight=0.000757, CigaretteCost = 0.19767857, VeinCode="", Active = true},
                new Brand {CodeFA = "FA050719.12", Description = "DELICADOSCLAROSLSRSP24",CigaretteCode = "7AZDS", CigaretteWeight=0.000807, TobaccoWeight=0.000651, CigaretteCost = 0.06928991, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA054619.17", Description = "DELICADOSORIGINALESLSRSP24",CigaretteCode = "7B7UH", CigaretteWeight=0.000798, TobaccoWeight=0.000651, CigaretteCost = 0.06888881, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA064011.03", Description = "MARLBOROKRETEKMINTMNTKSBOX20",CigaretteCode = "7AOLP", CigaretteWeight=0.000894, TobaccoWeight=0.000674, CigaretteCost = 0.12786383, VeinCode="V0N7G", Active = true},
                new Brand {CodeFA = "FA044071.05", Description = "DIPLOMAT100BOX10",CigaretteCode = "7B7NE", CigaretteWeight=0.001045, TobaccoWeight=0.000859, CigaretteCost = 0.09706998, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA067870.00", Description = "MARLBORODBLFUPURMNTKSBOX10",CigaretteCode = "7AXUF", CigaretteWeight=0.000873, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA062737.00", Description = "L&MFASTFORWARDPURPLEMNTKSBOX20",CigaretteCode = "7AWHM", CigaretteWeight=0.000819, TobaccoWeight=0.000608, CigaretteCost = 0.13164595, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA015677.17", Description = "RUBIOSKSBOX20",CigaretteCode = "7B7MY", CigaretteWeight=0.000901, TobaccoWeight=0.00075, CigaretteCost = 0.08520279, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA066958.00", Description = "MARLBOROBLUEICE(2.5)MNTKSBOX20",CigaretteCode = "7AXVL", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12949901, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA031790.12", Description = "MARLBOROBLUEICEMNTKSBOX20",CigaretteCode = "7B7PL", CigaretteWeight=0.000825, TobaccoWeight=0.000608, CigaretteCost = 0.1284404, VeinCode="V0L5Y", Active = true},
                new Brand {CodeFA = "FA041174.08", Description = "L&MFORWARDKSBOX20",CigaretteCode = "7AFLC", CigaretteWeight=0.000859, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA068058.00", Description = "L&M(RED)MNTKSBOX20",CigaretteCode = "7AZTB", CigaretteWeight=0.00086, TobaccoWeight=0.000648, CigaretteCost = 0.12988874, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA041173.02", Description = "L&MFORWARDKSBOX20",CigaretteCode = "7AFLC", CigaretteWeight=0.000859, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA068808.01", Description = "CHESTERFIELDBLUE(4.0)KSBOX14",CigaretteCode = "7B7VW", CigaretteWeight=0.000818, TobaccoWeight=0.000629, CigaretteCost = 0.06894387, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA065998.00", Description = "MARLBOROGOLD(2.5)RSRCB20",CigaretteCode = "7AYLU", CigaretteWeight=0.000721, TobaccoWeight=0.00053, CigaretteCost = 0.07384012, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA065999.02", Description = "MARLBORO(RED2.5)LSBOX14",CigaretteCode = "7AXYN", CigaretteWeight=0.000788, TobaccoWeight=0.000608, CigaretteCost = 0.08507672, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA066063.01", Description = "MARLBOROICEXPME2MNT100BOX20",CigaretteCode = "7AVAD", CigaretteWeight=0.000999, TobaccoWeight=0.000773, CigaretteCost = 0.1772851, VeinCode="V0L5Y", Active = true},
                new Brand {CodeFA = "FA050078.18", Description = "BENSON&HEDGESGOLD100RCB20",CigaretteCode = "7AXWD", CigaretteWeight=0.001006, TobaccoWeight=0.000818, CigaretteCost = 0.10007157, VeinCode="V0P8V", Active = true},
                new Brand {CodeFA = "FA062309.02", Description = "MARLBOROKRETEKMINTMNTKSBOX20",CigaretteCode = "7ARAZ", CigaretteWeight=0.000886, TobaccoWeight=0.000681, CigaretteCost = 0.14553963, VeinCode="V0N7G", Active = true},
                new Brand {CodeFA = "FA044088.01", Description = "MARLBORO(REDUPGRADE)KSBOX10",CigaretteCode = "7B7MQ", CigaretteWeight=0.000878, TobaccoWeight=0.000718, CigaretteCost = 0.09549794, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA065995.00", Description = "MARLBOROGOLD(2.5)KSSOF20",CigaretteCode = "7AZ7V", CigaretteWeight=0.000826, TobaccoWeight=0.000594, CigaretteCost = 0.08410812, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA047489.04", Description = "MARLBORO(REDFWD)KSBOX20",CigaretteCode = "7B7MP", CigaretteWeight=0.000907, TobaccoWeight=0.000718, CigaretteCost = 0.09613629, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA032539.07", Description = "MARLBORO(REDUPGRADE)KSBOX20",CigaretteCode = "7B7MQ", CigaretteWeight=0.000877, TobaccoWeight=0.000718, CigaretteCost = 0.09549794, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA056725.01", Description = "MARLBORO(REDFWD)KSBOX20",CigaretteCode = "7B7MR", CigaretteWeight=0.000907, TobaccoWeight=0.000718, CigaretteCost = 0.09729644, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA059077.07", Description = "BENSON&HEDGESMENTHOLPMNT100SOF20",CigaretteCode = "7ATVP", CigaretteWeight=0.000985, TobaccoWeight=0.000771, CigaretteCost = 0.14120366, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA065752.01", Description = "MARLBOROGOLD(2.5)KSBOX20",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0.000601, CigaretteCost = 0.09482075, VeinCode="", Active = true},
                new Brand {CodeFA = "FA021511.10", Description = "MARLBOROGOLDORIGINALKSBOX20",CigaretteCode = "7B7MS", CigaretteWeight=0.000788, TobaccoWeight=0.000601, CigaretteCost = 0.09261448, VeinCode="V0C83", Active = true},
                new Brand {CodeFA = "FA067073.01", Description = "MARLBOROGOLD(2.5)KSBOX20",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0.000601, CigaretteCost = 0.09482075, VeinCode="", Active = true},
                new Brand {CodeFA = "FA031788.03", Description = "MARLBOROBLUEICEMNTKSBOX20",CigaretteCode = "7AELJ", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12754107, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA065996.00", Description = "MARLBOROGOLD(2.5)KSRCB14",CigaretteCode = "7AYLN", CigaretteWeight=0.000822, TobaccoWeight=0.000589, CigaretteCost = 0.07815105, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA050312.07", Description = "FAROSNFRSSOF18SLI",CigaretteCode = "FAW01", CigaretteWeight=0.000731, TobaccoWeight=0.000731, CigaretteCost = 0.05818084, VeinCode="V0L5W", Active = true},
                new Brand {CodeFA = "FA069079.00", Description = "MARLBOROGOLD(2.5)KSBOX10",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0.000601, CigaretteCost = 0.09482075, VeinCode="V0C83", Active = true},
                new Brand {CodeFA = "FA055991.00", Description = "MARLBOROBLUEICEMNTKSBOX10",CigaretteCode = "7AELJ", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12754107, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA015678.11", Description = "RUBIOSMNTKSBOX20",CigaretteCode = "7B7NT", CigaretteWeight=0.000902, TobaccoWeight=0.000753, CigaretteCost = 0.08719628, VeinCode="V0C85", Active = true},
                new Brand {CodeFA = "FA044120.02", Description = "L&MFORWARDKSBOX20",CigaretteCode = "7AFLC", CigaretteWeight=0.000859, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA056679.11", Description = "BENSON&HEDGESMINTPEARMNT100RCB20",CigaretteCode = "7AJDW", CigaretteWeight=0.000984, TobaccoWeight=0.000771, CigaretteCost = 0.14207071, VeinCode="0", Active = true},
                new Brand {CodeFA = "FA069042.00", Description = "CHESTERFIELDBLUE(4.0)LSRSP24",CigaretteCode = "7B7XO", CigaretteWeight=0.000809, TobaccoWeight=0.000651, CigaretteCost = 0.06668233, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA050967.01", Description = "DIPLOMATEVOMNT100BOX10",CigaretteCode = "7B7JU", CigaretteWeight=0.001038, TobaccoWeight=0.000822, CigaretteCost = 0.14412011, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA044072.04", Description = "DIPLOMATMNT100BOX10",CigaretteCode = "7B7NS", CigaretteWeight=0.001045, TobaccoWeight=0.000862, CigaretteCost = 0.09879416, VeinCode="V0C85", Active = true},
                new Brand {CodeFA = "FA068056.00", Description = "L&M(RED)MNTKSBOX20",CigaretteCode = "7AZTC", CigaretteWeight=0.000866, TobaccoWeight=0.00065, CigaretteCost = 0.1251632, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA059078.10", Description = "BENSON&HEDGESMENTHOLPMNT100BOX14",CigaretteCode = "7ATVP", CigaretteWeight=0.000985, TobaccoWeight=0.000771, CigaretteCost = 0.14120366, VeinCode="V0L5Z", Active = true},
                new Brand {CodeFA = "FA068922.01", Description = "MARLBORODFUSIONVMNT100BOX20",CigaretteCode = "7AZJL", CigaretteWeight=0.001027, TobaccoWeight=0.000755, CigaretteCost = 0.1991335, VeinCode="V0M5Y", Active = true},
                new Brand {CodeFA = "FA041178.07", Description = "L&MFORWARDKSBOX20",CigaretteCode = "7AFLC", CigaretteWeight=0.000859, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="", Active = true},
                new Brand {CodeFA = "FA067812.02", Description = "MARLBOROBLUEICE(2.5)MNTKSBOX20",CigaretteCode = "7AXVL", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12949901, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA067068.00", Description = "MARLBORODBLFUPURMNTKSBOX20",CigaretteCode = "7AXUF", CigaretteWeight=0.000872, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA048930.08", Description = "FAROSKSSOF20",CigaretteCode = "7AKWF", CigaretteWeight=0.000805, TobaccoWeight=0.000657, CigaretteCost = 0.07174799, VeinCode="V0L6F", Active = true},
                new Brand {CodeFA = "FA035064.11", Description = "L&METIQUETAROJAKSSOF20",CigaretteCode = "7B7MW", CigaretteWeight=0.00091, TobaccoWeight=0.00075, CigaretteCost = 0.08228816, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA036713.13", Description = "L&METIQUETAAZULKSSOF20",CigaretteCode = "7B7MQ", CigaretteWeight=0.00091, TobaccoWeight=0.00075, CigaretteCost = 0.09549794, VeinCode="", Active = true},
                new Brand {CodeFA = "FA001849.18", Description = "RUBIOSKSSOF20",CigaretteCode = "7B7MY", CigaretteWeight=0.000911, TobaccoWeight=0.00075, CigaretteCost = 0.08520279, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA069844.00", Description = "MARLBOROGOLD(2.5)100RCB20",CigaretteCode = "7AYDG", CigaretteWeight=0.000965, TobaccoWeight=0.000752, CigaretteCost = 0.13086949, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066041.03", Description = "MARLBORO(RED2.5)100BOX20",CigaretteCode = "7AVJD", CigaretteWeight=0.000971, TobaccoWeight=0.000756, CigaretteCost = 0.14790539, VeinCode="", Active = true},
                new Brand {CodeFA = "FA067876.00", Description = "CHESTERFIELDBLUE(CROWN3.0)KSBOX20",CigaretteCode = "7AYQS", CigaretteWeight=0.000792, TobaccoWeight=0.000604, CigaretteCost = 0.07380683, VeinCode="V0L6G", Active = true},
                new Brand {CodeFA = "FA067873.00", Description = "CHESTERFIELDRED(CROWN3.0)KSBOX20",CigaretteCode = "7AYQT", CigaretteWeight=0.00081, TobaccoWeight=0.000669, CigaretteCost = 0.06577808, VeinCode="V0L6G", Active = true},
                new Brand {CodeFA = "FA067871.00", Description = "CHESTERFIELDRED(CROWN3.0)KSBOX20",CigaretteCode = "7AYQT", CigaretteWeight=0.00081, TobaccoWeight=0.000669, CigaretteCost = 0.06577808, VeinCode="V0L6G", Active = true},
                new Brand {CodeFA = "FA055993.00", Description = "MARLBOROBLUEICEMNTKSBOX10",CigaretteCode = "7AELJ", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12754107, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA066962.02", Description = "MARLBOROBLUEICE(2.5)MNTKSBOX10",CigaretteCode = "7AXVL", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12949901, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA069078.00", Description = "MARLBORO(REDFWD)KSBOX10",CigaretteCode = "7B7MR", CigaretteWeight=0.000907, TobaccoWeight=0.000718, CigaretteCost = 0.09729644, VeinCode="V0Q2S", Active = true},
                new Brand {CodeFA = "FA065897.02", Description = "L&MFORWARDKSBOX10",CigaretteCode = "7AFLC", CigaretteWeight=0.000859, TobaccoWeight=0.000645, CigaretteCost = 0.12439044, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA067069.00", Description = "MARLBORODBLFUPURMNTKSBOX10",CigaretteCode = "7AXUF", CigaretteWeight=0.000872, TobaccoWeight=0.000605, CigaretteCost = 0.17298335, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA067056.00", Description = "L&MFASTFORWARDPURPLEMNTKSBOX10",CigaretteCode = "7BAS7", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.1285954, VeinCode="", Active = true},
                new Brand {CodeFA = "FA062739.01", Description = "L&MFASTFORWARDPURPLEMNTKSBOX20",CigaretteCode = "7AWHM", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.13164595, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA069681.01", Description = "MARLBOROGOLD(3.0ORIGINAL)KSBOX20",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0.000601, CigaretteCost = 0.09482075, VeinCode="V0C83", Active = true},
                new Brand {CodeFA = "FA041175.02", Description = "L&MFASTFORWARDMNTKSBOX20",CigaretteCode = "7AFLO", CigaretteWeight=0.000871, TobaccoWeight=0.000651, CigaretteCost = 0.12681626, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA041176.06", Description = "L&MFASTFORWARDMNTKSBOX20",CigaretteCode = "7AFLO", CigaretteWeight=0.000871, TobaccoWeight=0.000651, CigaretteCost = 0.12681626, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA049599.00", Description = "MARLBOROBLUEICEMNTKSBOX14",CigaretteCode = "7AELJ", CigaretteWeight=0.000823, TobaccoWeight=0.000608, CigaretteCost = 0.12754107, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA034075.23", Description = "BENSON&HEDGESGOLD100BOX14",CigaretteCode = "7AXWD", CigaretteWeight=0.001005, TobaccoWeight=0.000818, CigaretteCost = 0.10007157, VeinCode="V0P8V", Active = true},
                new Brand {CodeFA = "FA069071.00", Description = "CHESTERFIELDORIGINAL(4.0)LSRSP24",CigaretteCode = "7BAP7", CigaretteWeight=0.000806, TobaccoWeight=0.000651, CigaretteCost = 0.07060986, VeinCode="", Active = true},
                new Brand {CodeFA = "FA056205.00", Description = "L&MFASTFORWARDMNTKSBOX10",CigaretteCode = "7AFLO", CigaretteWeight=0.000871, TobaccoWeight=0.000651, CigaretteCost = 0.12681626, VeinCode="V0O5J", Active = true},
                new Brand {CodeFA = "FA047508.05", Description = "MARLBORO(REDFWD)KSBOX20",CigaretteCode = "7B7MR", CigaretteWeight=0.000907, TobaccoWeight=0, CigaretteCost = 0.09729644, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066041.05", Description = "MARLBORO (RED 2.5) 100 BOX 20",CigaretteCode = "7AVJD", CigaretteWeight=0.000982, TobaccoWeight=0, CigaretteCost = 0.14790539, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA065916.02", Description = "BENSO CRYSBLUE MNT 100 BOX 20 SLI",CigaretteCode = "7AYCA", CigaretteWeight=0.000805, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070345.00", Description = "MARLBORO JUST KS BOX 20",CigaretteCode = "7BBDS", CigaretteWeight=0.000775, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA068650.02", Description = "MARLBORO GOLD (2.5) 100 BOX 14",CigaretteCode = "7AYDG", CigaretteWeight=0.000965, TobaccoWeight=0, CigaretteCost = 0.13086949, VeinCode="V0L8J", Active = true},
                new Brand {CodeFA = "FA069847.00", Description = "MARLBORO GOLD (2.5) 100 BOX 14",CigaretteCode = "7AYDG", CigaretteWeight=0.000965, TobaccoWeight=0, CigaretteCost = 0.13086949, VeinCode="", Active = true},
                new Brand {CodeFA = "FA067871.01", Description = "CHESTERFIELD RED (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJT", CigaretteWeight=0.000859, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA067873.01", Description = "CHESTERFIELD RED (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJT", CigaretteWeight=0.000859, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA067876.01", Description = "CHESTERFIELD BLUE (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJS", CigaretteWeight=0.000836, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA067874.01", Description = "CHESTERFIELD BLUE (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJS", CigaretteWeight=0.000836, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C86", Active = true},
                new Brand {CodeFA = "FA047500.03", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7B7MR", CigaretteWeight=0.000907, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA067685.01", Description = "MARLBORO RED 25 KS BOX 20",CigaretteCode = "7ASQD", CigaretteWeight=0.000835, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0L5U", Active = true},
                new Brand {CodeFA = "FA066958.02", Description = "MARLBORO BLUE ICE (2.5) MNT KS BOX 20",CigaretteCode = "7AXVL", CigaretteWeight=0.000823, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0L8P", Active = true},
                new Brand {CodeFA = "FA066648.02", Description = "MARLBORO DBLFUPUR MNT KS BOX 20",CigaretteCode = "7AXUF", CigaretteWeight=0.000868, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA062735.01", Description = "L&M FAST FORWARD PURPLE MNT KS BOX 20",CigaretteCode = "7AWHM", CigaretteWeight=0.000809, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0P5N", Active = true},
                new Brand {CodeFA = "FA069790.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 10",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0, CigaretteCost = 0, VeinCode="V0C84", Active = true},
                new Brand {CodeFA = "FA067686.01", Description = "MARLBORO GOLD (2.5) KS BOX 20",CigaretteCode = "7ARRJ", CigaretteWeight=0.000813, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069829.00", Description = "MARLBORO GOLD (2.5) KS RCB 14",CigaretteCode = "7AYLN", CigaretteWeight=0.000827, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069828.00", Description = "MARLBORO GOLD (2.5) KS RCB 20",CigaretteCode = "7AYLN", CigaretteWeight=0.000827, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070826.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070365.00", Description = "MARLBORO DBLSURU2 MNT 100 BOX 14  ",CigaretteCode = "7AZJJ", CigaretteWeight=0.001027, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA054610.02", Description = "L&M RED LABEL KS SOF 20",CigaretteCode = "7B7MX", CigaretteWeight=0.000908, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA065916.03", Description = "BENSO CRYSBLUE MNT 100 BOX 20 SLI  ",CigaretteCode = "7AYCA", CigaretteWeight=0.000797, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069038.02", Description = "CHESTERFIELD REMIXPUR MNT 100 BOX 20",CigaretteCode = "7B7VZ", CigaretteWeight=0.000973, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA046228.01", Description = "DIPLOMAT EVO MNT 100 BOX 20",CigaretteCode = "7B7JU", CigaretteWeight=0.00104, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066044.02", Description = "MARLBORO GOLD (3.0 ORIGINAL) 100 BOX 14  ",CigaretteCode = "7BBDP", CigaretteWeight=0.000965, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066044.01", Description = "MARLBORO GOLD (3.0 ORIGINAL) 100 BOX 14  ",CigaretteCode = "7BBDP", CigaretteWeight=0.000965, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069048.00", Description = "CHESTERFIELD BLUE (4.0) KS BOX 20",CigaretteCode = "7B7VW", CigaretteWeight=0.000818, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA062737.03", Description = "L&M FAST FORWARD PURPLE MNT KS BOX 20",CigaretteCode = "7BAS7", CigaretteWeight=0.000906, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059078.11", Description = "BENSON & HEDGES MINTPEAR MNT 100 RCB 20",CigaretteCode = "7AJDW", CigaretteWeight=0.000984, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069680.01", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0.000823, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070381.00", Description = "MARLBORO (RED 2.5) 100 BOX 20",CigaretteCode = "7AVJD", CigaretteWeight=0.000976, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048687.12", Description = "DERBY ROJO ORIGINAL KS SOF 20",CigaretteCode = "7BBUV", CigaretteWeight=0.000848, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA056679.13", Description = "BENSON & HEDGES MINTPEAR MNT 100 RCB 20",CigaretteCode = "7AJDW", CigaretteWeight=0.000972, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA043177.02", Description = "DIPLOMAT 100 BOX 20",CigaretteCode = "7B7NE", CigaretteWeight=0.001001, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA056244.00", Description = "DIPLOMAT EVO PLUS MNT 100 BOX 20",CigaretteCode = "7B7JV", CigaretteWeight=0.001018, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069037.02", Description = "CHESTERFIELD REMIXSIN MNT 100 BOX 20",CigaretteCode = "7B7VY", CigaretteWeight=0.001042, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048694.12", Description = "DERBY AZUL BALANCEADO KS SOF 20",CigaretteCode = "7BBUW", CigaretteWeight=0.000855, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069830.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS RCB 20",CigaretteCode = "7BBDO", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059079.11", Description = "BENSON & HEDGES MENTHOLP MNT 100 RCB 20",CigaretteCode = "7ATVP", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA068986.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS RCB 14",CigaretteCode = "7BBDO", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA044088.02", Description = "MARLBORO (RED UPGRADE) KS BOX 10",CigaretteCode = "7BCBQ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069078.01", Description = "MARLBORO (RED FWD) KS BOX 10",CigaretteCode = "7BCBJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA066000.01", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS SOF 20",CigaretteCode = "7BBDN", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048696.15", Description = "DERBY ROJO ORIGINAL KS BOX 20",CigaretteCode = "7BBUV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048699.14", Description = "DERBY AZUL BALANCEADO KS BOX 20",CigaretteCode = "7BBUW", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA051401.11", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7BCBJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA056725.02", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7BCBJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA032539.08", Description = "MARLBORO (RED UPGRADE) KS BOX 20",CigaretteCode = "7BCBQ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA047500.04", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7BCBJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA047508.06", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7BCBJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA063749.03", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7B7MR", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070920.00", Description = "MARLBORO SHUFFLE MNT 100 BOX 20",CigaretteCode = "7BBYQ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070068.00", Description = "L&M FORWARD BLUE KS BOX 20",CigaretteCode = "7AFLC", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069846.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) 100 RCB 20",CigaretteCode = "7BBDP", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069682.01", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA063062.04", Description = "BENSO CRYSTALV MNT 100 BOX 20 SLI",CigaretteCode = "7AUYI", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059743.00", Description = "MARLBORO BLUE ICE (2.0) MNT KS BOX 10",CigaretteCode = "7AXHJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA068985.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS RCB 20",CigaretteCode = "7BBDO", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA062733.04", Description = "DERBY MENTOL CAPS MNT KS BOX 20",CigaretteCode = "7AUPD", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048699.17", Description = "DERBY AZUL BALANCEADO KS BOX 20",CigaretteCode = "7BBUW", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070811.00", Description = "L&M RED LABEL KS BOX 20",CigaretteCode = "7BBSY", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059802.00", Description = "MARLBORO BLUE ICE (2.0) MNT KS BOX 20",CigaretteCode = "7AXHJ", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048700.13", Description = "DERBY AZUL BALANCEADO KS BOX 20",CigaretteCode = "7BBUW", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA055877.11", Description = "BENSON & HEDGES GOLDPEARL 100 RCB 20",CigaretteCode = "7AYTP", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069679.03", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA068922.04", Description = "MARLBORO DFUSIONV MNT 100 BOX 20",CigaretteCode = "7BBAV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA065998.01", Description = "MARLBORO GOLD (2.5) RS RCB 20",CigaretteCode = "7AYLU", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048697.12", Description = "DERBY ROJO ORIGINAL KS BOX 20",CigaretteCode = "7BBUV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA059077.08", Description = "BENSON & HEDGES MENTHOLP MNT 100 SOF 20",CigaretteCode = "7ATVP", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA047489.05", Description = "MARLBORO (RED FWD) KS BOX 20",CigaretteCode = "7BCBR", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048694.15", Description = "DERBY AZUL BALANCEADO KS SOF 20",CigaretteCode = "7BBUW", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048687.14", Description = "DERBY ROJO ORIGINAL KS SOF 20",CigaretteCode = "7BBUV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048693.05", Description = "DERBY ROJO ORIGINAL KS SOF 20",CigaretteCode = "7BBUV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048695.05", Description = "DERBY AZUL BALANCEADO KS SOF 20",CigaretteCode = "7BBUW", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070069.02", Description = "L&M FORWARD BLUE KS BOX 20",CigaretteCode = "7AFLC", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070070.00", Description = "L&M FORWARD BLUE KS BOX 20",CigaretteCode = "7AFLC", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048696.18", Description = "DERBY ROJO ORIGINAL KS BOX 20",CigaretteCode = "7BBUV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA048691.06", Description = "L&M RED LABEL KS BOX 20",CigaretteCode = "7BBSY", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069681.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA069682.00", Description = "MARLBORO GOLD (3.0 ORIGINAL) KS BOX 20",CigaretteCode = "7B7MU", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA068922.03", Description = "MARLBORO DFUSIONV MNT 100 BOX 20",CigaretteCode = "7BBAV", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA070810.00", Description = "L&M RED LABEL KS BOX 10",CigaretteCode = "7BBSY", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA065914.04", Description = "MARLBORO D-FUSION AMBER (2.5) 100 BOX 20",CigaretteCode = "7AZJK", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA067872.01", Description = "CHESTERFIELD RED (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJT", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true},
                new Brand {CodeFA = "FA067875.01", Description = "CHESTERFIELD BLUE (CROWN 3.0) KS BOX 20",CigaretteCode = "7BBJS", CigaretteWeight=0, TobaccoWeight=0, CigaretteCost = 0, VeinCode="", Active = true}
            };
            brands.ForEach(c => context.Brands.AddOrUpdate(p => p.CodeFA, c));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department {IdLESMES = 100877069, Name = "BU4", Facility = "MS14", Company="PMMX", CalendarID=100000002, Active= true },
                new Department {IdLESMES = 100877066, Name = "CELL 1", Facility = "MS14", Company="PMMX", CalendarID=100000008, Active= true },
                new Department {IdLESMES = 100877067, Name = "CELL 2", Facility = "MS14", Company="PMMX", CalendarID=100000002, Active= true },
                new Department {IdLESMES = 100877068, Name = "CELL 3", Facility = "MS14", Company="PMMX", CalendarID=100000002, Active= true },
                new Department {IdLESMES = 101116437, Name = "SECONDARY 2", Facility = "MS14", Company="PMMX", CalendarID=100000008, Active= true },
                new Department {IdLESMES = 101116438, Name = "UBER", Facility = "MS14", Company="PMMX", CalendarID=100000008, Active= true }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.IdLESMES, s));
            context.SaveChanges();

            var workCenters = new List<WorkCenter>
            {
                new WorkCenter {TextID = 100882644, Name = "FI1", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101107235, Name = "FI11", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101111259, Name = "FI12", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101111262, Name = "FI13", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100905618, Name = "FI2", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100907188, Name = "FI3", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100907191, Name = "FI4", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100929303, Name = "FI5", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100929306, Name = "FI6", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100929309, Name = "FI7", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101032317, Name = "FI8", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101032320, Name = "FI9", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 100905621, Name = "A1", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100933640, Name = "A2", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929312, Name = "A3", Facility = "MS14", Company="PMMX", DepartmentName="CELL 3", Active= true },
                new WorkCenter {TextID = 100929315, Name = "A4", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929318, Name = "A5", Facility = "MS14", Company="PMMX", DepartmentName="UBER", Active= true },
                new WorkCenter {TextID = 100929321, Name = "A6", Facility = "MS14", Company="PMMX", DepartmentName="UBER", Active= true },
                new WorkCenter {TextID = 100929324, Name = "B1", Facility = "MS14", Company="PMMX", DepartmentName="CELL 2", Active= true },
                new WorkCenter {TextID = 100929327, Name = "B2", Facility = "MS14", Company="PMMX", DepartmentName="CELL 2", Active= true },
                new WorkCenter {TextID = 100929330, Name = "B3", Facility = "MS14", Company="PMMX", DepartmentName="CELL 2", Active= true },
                new WorkCenter {TextID = 100929333, Name = "B4", Facility = "MS14", Company="PMMX", DepartmentName="CELL 3", Active= true },
                new WorkCenter {TextID = 100933643, Name = "B6", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 101023368, Name = "B7", Facility = "MS14", Company="PMMX", DepartmentName="UBER", Active= true },
                new WorkCenter {TextID = 101023374, Name = "B8", Facility = "MS14", Company="PMMX", DepartmentName="UBER", Active= true },
                new WorkCenter {TextID = 100929366, Name = "C1", Facility = "MS14", Company="PMMX", DepartmentName="CELL 3", Active= true },
                new WorkCenter {TextID = 100929369, Name = "C2", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929369, Name = "C3", Facility = "MS14", Company="PMMX", DepartmentName="CELL 1", Active= true },
                new WorkCenter {TextID = 100929372, Name = "C4", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929375, Name = "C5", Facility = "MS14", Company="PMMX", DepartmentName="CELL 1", Active= true },
                new WorkCenter {TextID = 101105289, Name = "C6", Facility = "MS14", Company="PMMX", DepartmentName="CELL 1", Active= true },
                new WorkCenter {TextID = 100929869, Name = "D1", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929872, Name = "D2", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929875, Name = "D3", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100933644, Name = "D4", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929878, Name = "D5", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929881, Name = "D6", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 100929884, Name = "D7", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 101105286, Name = "E2", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 101105286, Name = "E3", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 101116480, Name = "E4", Facility = "MS14", Company="PMMX", DepartmentName="SECONDARY 2", Active= true },
                new WorkCenter {TextID = 101032348, Name = "MULF1", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true },
                new WorkCenter {TextID = 101111249, Name = "MULF2", Facility = "MS14", Company="PMMX", DepartmentName="BU4", Active= true }
            };
            workCenters.ForEach(s => context.WorkCenters.AddOrUpdate(p => p.TextID, s));
            context.SaveChanges();

            var wasteDepartment = new List<WasteDepartment>
            {
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("BU4")).Name,
                    Value = 1.9,
                    Active = true
                },
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("CELL 1")).Name,
                    Value = 1.9,
                    Active = true
                },
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("CELL 2")).Name,
                    Value = 1.9,
                    Active = true
                },
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("CELL 3")).Name,
                    Value = 1.9,
                    Active = true
                },
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("SECONDARY 2")).Name,
                    Value = 1.9,
                    Active = true
                },
                new WasteDepartment {
                    IdDepartment = departments.Single(s => s.Name.Equals("UBER")).Name,
                    Value = 1.9,
                    Active = true
                },
            };

            foreach (WasteDepartment w in wasteDepartment)
            {
                var enrollmentInDataBase = context.WasteDepartments
                    .Where( s => s.Department.Name == w.IdDepartment).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.WasteDepartments.Add(w);
                }
            }
            context.SaveChanges();

            var wasteWorkCenter = new List<WasteWorkCenter>
            {
                new WasteWorkCenter {
                    IdWorkCenter = workCenters.Single(s => s.Name.Equals("A1")).Name,
                    Value = 0,
                    Active = true
                },
                new WasteWorkCenter {
                    IdWorkCenter = workCenters.Single(s => s.Name.Equals("A2")).Name,
                    Value = 0,
                    Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("A3")).Name,
                Value = 1.8,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("A4")).Name,
                Value = 0,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("A5")).Name,
                Value = 1.97,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("A6")).Name,
                Value = 1.97,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B1")).Name,
                Value = 1.75,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B2")).Name,
                Value = 1.7,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B3")).Name,
                Value = 1.5,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B4")).Name,
                Value = 2.05,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B5")).Name,
                Value = 0,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B6")).Name,
                Value = 2.6,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B7")).Name,
                Value = 1.97,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("B8")).Name,
                Value = 1.98,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C1")).Name,
                Value = 1.6,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C2")).Name,
                Value = 2.8,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C3")).Name,
                Value = 1.4,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C4")).Name,
                Value = 1.8,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C5")).Name,
                Value = 1.1,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C6")).Name,
                Value = 1.8,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("C7")).Name,
                Value = 0,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D1")).Name,
                Value = 2.6,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D2")).Name,
                Value = 0,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D3")).Name,
                Value = 1.3,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D4")).Name,
                Value = 0,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D5")).Name,
                Value = 3,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D6")).Name,
                Value = 1.4,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("D7")).Name,
                Value = 3,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("E1")).Name,
                Value = 4,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("E2")).Name,
                Value = 3.9,
                Active = true
                },
                new WasteWorkCenter {
                IdWorkCenter = workCenters.Single(s => s.Name.Equals("E3")).Name,
                Value = 3.7,
                Active = true
                }
            };

            foreach (WasteWorkCenter w in wasteWorkCenter)
            {
                var enrollmentInDataBase = context.WasteWorkCenters
                    .Where(s => s.WorkCenter.Name == w.IdWorkCenter).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.WasteWorkCenters.Add(w);
                }
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}

<footer>
    <p>&copy; 2021 - Positive Education Program</p>
</footer>
   <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj" crossorigin="anonymous"></script>
       <script type="text/javascript">
           document.addEventListener("DOMContentLoaded", function () {
               // make it as accordion for smaller screens
               if (window.innerWidth < 992) {
                  
                   // close all inner dropdowns when parent is closed
                   document.querySelectorAll('.navbar .dropdown').forEach(function (everydropdown) {
                       everydropdown.addEventListener('hidden.bs.dropdown', function () {
                           // after dropdown is hidden, then find all submenus
                           this.querySelectorAll('.submenu').forEach(function (everysubmenu) {
                               // hide every submenu as well
                               everysubmenu.style.display = 'none';
                           });
                       })
                   });

                   document.querySelectorAll('.dropdown-menu a').forEach(function (element) {
                       element.addEventListener('click', function (e) {
                           let nextEl = this.nextElementSibling;
                           if (nextEl && nextEl.classList.contains('submenu')) {
                               // prevent opening link if link needs to open dropdown
                               e.preventDefault();
                               if (nextEl.style.display == 'block') {
                                   nextEl.style.display = 'none';
                               } else {
                                   nextEl.style.display = 'block';
                               }

                           }
                       });
                   })
               }
               // end if innerWidth
           });
       </script>
    </body>
</html>
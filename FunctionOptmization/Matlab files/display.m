% Function
a = 1; b = 5; c = -4; d = 5; l = 5; k = -4;
f = @(x) a*x(1)^4 - b*x(1)*x(2)^2 + c*x(2)^2*x(3)^2 - d*x(3)^3 + l*x(1) - k*x(2) + exp(x(3)) - log(x(1)^2 + x(2)^2 + 1);

% Point of interest
x = [-1.0766, -0.4306, -0.2794];

[x1, x2, x3] = meshgrid(-5:0.1:5, -5:0.1:5, -5:0.1:5);
f_values = a*x1.^4 - b*x1.*x2.^2 + c*x2.^2.*x3.^2 - d*x3.^3 + l*x1 - k*x2 + exp(x3) - log(x1.^2 + x2.^2 + 1);

figure;
isosurface(x1, x2, x3, f_values, 0);
xlabel('X');
ylabel('Y');
zlabel('Z');
title('Gradient descent method');

hold on;

scatter3(x(1), x(2), x(3), 'r', 'filled');
text(x(1), x(2), x(3), sprintf('Local minima: f(%0.2f,%0.2f,%0.2f)=%0.2f', x(1), x(2), x(3), f(x)));

hold off;
% Function
a = 1; b = 5; c = -4; d = 5; l = 5; k = -4;
f = @(x) a*x(1)^4 - b*x(1)*x(2)^2 + c*x(2)^2*x(3)^2 - d*x(3)^3 + l*x(1) - k*x(2) + exp(x(3)) - log(x(1)^2 + x(2)^2 + 1);

% Starting point
x0 = [-2, -2, -2];

options = optimset('OutputFcn',@outfun,'Display','iter');
x = fminsearch(f, x0, options);

disp(x);

function stop = outfun(x, optimValues, state)
    stop = false;
    switch state
        case 'iter'
            fprintf('%f %f %f\n', x(1), x(2), x(3));
    end
end
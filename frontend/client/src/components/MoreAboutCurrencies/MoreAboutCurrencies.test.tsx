import { fireEvent, render, screen } from '@testing-library/react';
import { MoreAboutCurrencies } from './MoreAboutCurrencies';

describe('MoreAboutCurrencies Component', () => {
  const currenciesData = [
    {
      code: 'PLN',
      title: 'Polish zloty - PLN - zł',
      description: 'This is the official currency and legal tender of Poland.'
    },
    {
      code: 'JPY',
      title: 'Japanese yen - JPY - ¥',
      description: 'The yen is the official currency of Japan.'
    }
  ];

  it('по умолчанию описание валют НЕ отображается', () => {
    render(<MoreAboutCurrencies currenciesData={currenciesData} />);

    expect(screen.queryByText(/Polish zloty - PLN - zł/)).toBeNull();
    expect(screen.queryByText(/Japanese yen - JPY - ¥/)).toBeNull();
  });

  it('при повторном клике описание валют исчезает', () => {
    render(<MoreAboutCurrencies currenciesData={currenciesData} />);

    const button = screen.getByText(/More about PLN\/JPY/i);

    fireEvent.click(button);
    expect(screen.getByText(/PLN\/JPY: about ↑/i));
    expect(screen.getByText(/Polish zloty - PLN - zł/)).toBeInTheDocument();

    fireEvent.click(button);
    expect(screen.queryByText(/Polish zloty - PLN - zł/)).toBeNull();
  });

  it('при клике на кнопку появляется описание валют', () => {
    render(<MoreAboutCurrencies currenciesData={currenciesData} />);

    const button = screen.getByText(/More about PLN\/JPY/i);
    fireEvent.click(button);

    expect(screen.getByText(/PLN\/JPY: about ↑/i));
    expect(screen.getByText(/Polish zloty - PLN - zł/)).toBeInTheDocument();
    expect(screen.getByText(/Japanese yen - JPY - ¥/)).toBeInTheDocument();
    expect(screen.getByText(/This is the official currency and legal tender of Poland/)).toBeInTheDocument();
    expect(screen.getByText(/The yen is the official currency of Japan/)).toBeInTheDocument();
  });
});
